using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerControllerAction action;
    public Vector2 inputDirection;
    public Vector3 inputDir3D;
    public Rigidbody rb;
    public float MoveSpeed;
    public bool canDialogue;
    public DialogManager currentDialoger;
    public bool isOnDia;
    private void Awake()
    {
        action = new PlayerControllerAction();
        rb = GetComponent<Rigidbody>();
        action.PlayerDialog.StartDialog.performed += DialogButtonPressed;
    }
    private void OnEnable()
    {
        action.Enable();
        Event.Instance.DialogerIn += SwitchDialoguer;
        Event.Instance.DialogerOut += SwitchDialoguer;
        Event.Instance.EndDialog += OnEndDialoge;
    }

    private void OnEndDialoge(DialogManager manager)
    {
       isOnDia = false;
        manager.isOnThisDialog = false;
        Event.Instance.CallCancelDialog(currentDialoger);
        action.PlayerNormal.Move.Enable();
        currentDialoger=null;
    }

    private void OnDisable()
    {
        action.Disable();
        Event.Instance.DialogerIn -= SwitchDialoguer;
        Event.Instance.DialogerOut -= SwitchDialoguer;
        Event.Instance.EndDialog -= OnEndDialoge;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = action.PlayerNormal.Move.ReadValue<Vector2>();
        inputDir3D = new Vector3(inputDirection.x, 0, inputDirection.y);
        if (inputDir3D.magnitude >= 1f)
        { inputDir3D.Normalize(); }

        rb.velocity = new Vector3(inputDir3D.x * MoveSpeed, rb.velocity.y, inputDir3D.z * MoveSpeed);

        if (inputDir3D.x > 0)
        { this.gameObject.transform.localScale = new Vector3(Mathf.Abs(this.gameObject.transform.localScale.x), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z); }
        if (inputDir3D.x < 0)
        { this.gameObject.transform.localScale = new Vector3(-Mathf.Abs(this.gameObject.transform.localScale.x), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z); }
    }
   void DialogButtonPressed(InputAction.CallbackContext context)
    {
        if (currentDialoger != null&&isOnDia==false)
        { currentDialoger.gameObject.GetComponent<DialogManager>().isOnThisDialog = true; 
         isOnDia = true;
        Event.Instance.CallStartDialog(currentDialoger);
            action.PlayerNormal.Move.Disable();
        }
        else if (currentDialoger != null && isOnDia == true)
        {
            currentDialoger.gameObject.GetComponent<DialogManager>().isOnThisDialog = false;
            isOnDia = false;
            Event.Instance.CallCancelDialog(currentDialoger);
            action.PlayerNormal.Move.Enable();

        }

    }
    public void SwitchDialoguer(DialogManager dialogToSwitch)
    { 
    currentDialoger = dialogToSwitch;
    }
    public void DialogCallupForAnimation()
    {
        if (currentDialoger != null && isOnDia == false)
        {
            currentDialoger.gameObject.GetComponent<DialogManager>().isOnThisDialog = true;
            isOnDia = true;
            Event.Instance.CallStartDialog(currentDialoger);
            action.PlayerNormal.Move.Disable();
        }
    }
    
}