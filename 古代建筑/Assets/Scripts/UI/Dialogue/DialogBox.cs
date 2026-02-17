using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour, IPointerClickHandler
{
    public DialogManager currentDialogManager;
    public DialogNodeSO currentDN;
    public GameObject dialogBox;
    public bool reading;
   
    public string fullTextString;
    public string currentTextString;
    public float typeSpeed;
    [SerializeField] private TMP_Text Text;
    public bool isrepeat;
    public Image avatar;

    private void OnEnable()
    {
        Event.Instance.StartDialog += OpenDiaBox;
        Event.Instance.CancelDialog += OnCancelDiaBox;

    }
    private void OnDisable()
    {
        Event.Instance.StartDialog -= OpenDiaBox;
        Event.Instance.CancelDialog -= OnCancelDiaBox;
    }
    public void OpenDiaBox(DialogManager dialogManager)
    {
        currentDialogManager = dialogManager;
        dialogBox.SetActive(true);
        currentDN = dialogManager.currentDialogNode;
        fullTextString = currentDN.Content;
        avatar.sprite = currentDN.speakerSprite;
        if (!isrepeat)
        {
            StartCoroutine(TypeCoroutine());
        }
    }
    public void OnCancelDiaBox(DialogManager dialogManager)
    { dialogBox.SetActive(false);
        dialogManager.currentDialogNode = currentDN;
    }

    private IEnumerator TypeCoroutine()
    {
        isrepeat = true;
        reading = true;
        int currentCharIndex = 0;


        while (currentCharIndex < fullTextString.Length&&reading)
        {



            currentTextString += fullTextString[currentCharIndex];
            Text.text += fullTextString[currentCharIndex];
            currentCharIndex++;

            
            yield return new WaitForSeconds(typeSpeed);
        }
        reading = false;
      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (reading) {
            StopCoroutine(TypeCoroutine());
            reading = false;
            Text.text = fullTextString;
                }
      else  if (!reading) {
            NextDialogue();
        }
    }

    public void NextDialogue()
    {

        if (!currentDN.willEnd && !currentDN.canOption)
        {
            Text.text = string.Empty;
            currentTextString = string.Empty;
            currentDN = currentDN.Next; avatar.sprite = currentDN.speakerSprite;
            fullTextString = currentDN.Content;
            isrepeat = false;
            if (!isrepeat)
            {
                StartCoroutine(TypeCoroutine());
            }
        }
        else if (currentDN.willEnd&&!currentDN.canOption&&currentDN.eWillStart==EStartWhat.None) {
            Text.text = string.Empty;
            currentTextString = string.Empty;
            currentDN = currentDN.Next; avatar.sprite = currentDN.speakerSprite; isrepeat = false;
            reading = false;
            Event.Instance.EndDialog.Invoke(currentDialogManager);
            currentDialogManager=null;
        }
       else if(currentDN.willEnd&&currentDN.eWillStart==EStartWhat.FirstGame && !currentDN.canOption)
        {
            Text.text = string.Empty;
            currentTextString = string.Empty;
            currentDN = currentDN.Next; avatar.sprite = currentDN.speakerSprite; isrepeat = false;
            reading = false;
            Event.Instance.EndDialog.Invoke(currentDialogManager);
            currentDialogManager = null;
            Event.Instance.CallRotateView();
        }
    }
}
public enum EStartWhat
{
    None,FirstGame
}
