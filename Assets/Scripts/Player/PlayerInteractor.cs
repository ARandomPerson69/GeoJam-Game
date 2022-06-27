using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public GameObject objectToInteract;

    public KeyCode interactKey;

    public bool canInteract;

    void Update()
    {
        if(Input.GetKeyDown(interactKey) && canInteract)
        {
            objectToInteract.GetComponent<Interactable>().Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.GetComponent<Interactable>())
        {
            objectToInteract = hit.gameObject;
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if(hit.gameObject == objectToInteract)
        {
            canInteract = false;
            objectToInteract = null;
        }
    }
}
