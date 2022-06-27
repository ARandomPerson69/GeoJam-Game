using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event Action<string, int> onStoryEvent;
    
    public static bool inDialogue;

    #region Singleton
    public static EventManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than two instances of EventManager detected!");
        }
    }
    #endregion

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            onStoryEvent?.Invoke("Talked to human over robot", 1);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            onStoryEvent?.Invoke("Talked to robot over human", 1);
        }
    }

    public void SetInDialogue(bool isInDialogue)
    {
        inDialogue = isInDialogue;
    }
}
