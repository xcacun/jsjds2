using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class ClickTrigger : MonoBehaviour
{
    public Camera UICamera;
    public GameObject circleImage;
    public Transform targetObject;
    public GameObject lizi;
    public Vector3 Biggest;
    public float enlargeTime;
    public float reduceTime;
    public EIntroduceWhat introduceWhat;
    public IntroduceContentSO introduceContentSO;
    public ClickTrigger[] threeTrigger;
    public GameObject GameEndButton;
    public bool hasTriggered;
    private void Update()
    {
       
        
    }
 public void  onTriggerClick() {
    StartCoroutine(DoAnimation());
        hasTriggered = true;
        Event.Instance.CallIntroduceOnUI(introduceContentSO);
        if (threeTrigger[0].hasTriggered&& threeTrigger[1].hasTriggered && threeTrigger[2].hasTriggered)
        { GameEndButton.gameObject.SetActive(true); }
    }
   IEnumerator DoAnimation()
    {
        circleImage.transform.DOScale(Biggest, enlargeTime);
        yield return  new WaitForSeconds(0.5f);
        circleImage.transform.DOScale(new Vector3(0,0,0),reduceTime);
        lizi.gameObject.SetActive(false);
        yield return new WaitForSeconds(reduceTime + 0.1f);
        transform.gameObject.SetActive(false);
    }
}

