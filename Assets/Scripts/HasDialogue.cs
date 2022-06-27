using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasDialogue : Interactable
{
    public List<Dialogue> initialDialogueList = new List<Dialogue>();

    public List<Dialogue> afterDialogueList = new List<Dialogue>();

    public string eventNameTrigger;

    public List<Dialogue> optionOneDialogueList = new List<Dialogue>();

    public List<Dialogue> optionTwoDialogueList = new List<Dialogue>();

    public bool isHuman;

    public override void Interact()
    {
        if(!EventManager.inDialogue)
        {
            DialogueManager.instance.StartDialogue(initialDialogueList, isHuman);
        }
    }
 
    void UseOptionalDialogue(string nameOfEvent, int optionNum)
    {
        if(nameOfEvent == eventNameTrigger)
        {
            if(optionNum == 1)
            {
            initialDialogueList = optionOneDialogueList;
            }
            else
            {
            initialDialogueList = optionTwoDialogueList;
            }
        }
    }

    void OnEnable()
    {
        EventManager.instance.onStoryEvent += UseOptionalDialogue;
    }

    void OnDisable()
    {
        EventManager.instance.onStoryEvent -= UseOptionalDialogue;
    }
}
