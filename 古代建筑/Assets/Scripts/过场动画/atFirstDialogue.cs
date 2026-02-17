using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atFirstDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    [SerializeField] private PlayerController playerController;




    private void Start()
    {
        callUpBox();
    }

    void callUpBox()
    { dialogueBox.SetActive(true);
        playerController.DialogCallupForAnimation();
    
    
    }
}
