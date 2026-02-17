using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RotateGameManager : MonoBehaviour
{
    public Image RotateViewGameUI;
    public GameObject RotateViewGame;
    public Image BlackImage;
    public float duration=1f;
    public float delayAfterDialog=1f;
    private void Start()
    {
    
      
    }
    private void OnEnable()
    {
         Event.Instance.RotateView += OnRotateView;
    }
    private void OnDisable()
    {
        Event.Instance.RotateView -= OnRotateView;
    }
    void GameThingsAppear()
    {
        RotateViewGame.SetActive(true);
    }
    void GameUIAppear()
    { RotateViewGameUI.gameObject.SetActive(true); }
    void OnRotateView()
    {
        GameThingsAppear();
        StartCoroutine(BlackImageAppear());

    }
    IEnumerator BlackImageAppear()
    { yield return new WaitForSeconds(delayAfterDialog);
        BlackImage.color=new Color(0,0,0,0);
       
        BlackImage.DOColor(new Color(0,0,0,1),duration);
       yield return new WaitForSeconds(duration+0.1f);
        GameUIAppear();
        BlackImageFade();
    }
    void BlackImageFade()
    {
       
        BlackImage.DOKill();
        BlackImage.DOColor(new Color(0,0,0,0),duration);}
}
