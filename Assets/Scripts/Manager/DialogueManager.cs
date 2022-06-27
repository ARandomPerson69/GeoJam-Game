using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<Dialogue> dialogueList = new List<Dialogue>();

    public Image humanDialogueBoxImageUI;
    public Image robotDialogueBoxImageUI;
    public Image portraitImageUI;

    public Text nameTextUI;
    public Text dialogueTextUI;

    public float typingDelay;
    public float setInDialogueDelay;

    public int dialogueNum;

    public bool isHuman;

    #region Singleton
    public static DialogueManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than two instances of DialogueManager detected!");
        }
    }
    #endregion

    public void StartDialogue(List<Dialogue> currentDialogueList, bool isItHuman)
    {
        EventManager.instance.SetInDialogue(true);

        //Resets dialogueNum and sets new dialogueList and isHuman
        dialogueNum = 0;
        dialogueList = currentDialogueList;
        isHuman = isItHuman;

        SetDisplayUI(true);

        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if(EventManager.inDialogue)
        {
            if(dialogueList.Count < dialogueNum + 1)
            {
                SetDisplayUI(false);
                StartCoroutine(DelayedSetInDialogue());
            }

            dialogueTextUI.text = "";

            //Displays DialogueUI and starts typing the dialogueText
            portraitImageUI.sprite = dialogueList[dialogueNum].portrait;
            nameTextUI.text = dialogueList[dialogueNum].name;
            StartCoroutine(TypeDialogueText());

            dialogueNum ++;
        }
    }

    IEnumerator TypeDialogueText()
    {
        foreach (char character in dialogueList[dialogueNum].text.ToCharArray())
        {
            dialogueTextUI.text += character;
            yield return new WaitForSeconds(typingDelay);
        }
    }

    void SetDisplayUI(bool isDisplayOn)
    {
        if(isHuman)
        {
            humanDialogueBoxImageUI.gameObject.SetActive(isDisplayOn);
        }
        else
        {
            robotDialogueBoxImageUI.gameObject.SetActive(isDisplayOn);
        }
        portraitImageUI.gameObject.SetActive(isDisplayOn);
        nameTextUI.gameObject.SetActive(isDisplayOn);
        dialogueTextUI.gameObject.SetActive(isDisplayOn);
    }

    IEnumerator DelayedSetInDialogue()
    {
        yield return new WaitForSeconds(setInDialogueDelay);
        EventManager.instance.SetInDialogue(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextDialogue();
        }
    }
}
