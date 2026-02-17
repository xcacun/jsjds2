using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDialogueCheck : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] DialogManager currentDialoger;
    private void OnTriggerEnter(Collider other)
    {
        controller.canDialogue = true;
        Event.Instance.CallDialogerIn(currentDialoger);
    }

    private void OnTriggerExit(Collider other)
    {
        controller.canDialogue = false;
        Event.Instance.CallDialogerOut(null);
    }
    private void Update()
    {
        
    }
}
