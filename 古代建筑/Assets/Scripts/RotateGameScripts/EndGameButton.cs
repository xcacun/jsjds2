using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class EndGameButton : MonoBehaviour
{
    public Image blackImage;
    public float duration = 0.5f;
    public GameObject ThingsAboutGame;
    public GameObject IntroduceGameUI;
    public CinemachineVirtualCamera PlayerFollow;
    public Camera Camera;
    public CinemachineBrain cinemachineBrain;
    private void OnEnable()
    {
        Event.Instance.IntroduceGameEnd += OnIntroduceGameEnd;
    }
    private void OnDisable()
    {
        Event.Instance.IntroduceGameEnd -= OnIntroduceGameEnd;
    }
    public void OnIntroduceGameEnd()
    {
      BlackImageAppear();
        StartCoroutine(DestoryAndBlackFade());
    }
    void BlackImageAppear()
    {
        blackImage.DOColor(new Color(0, 0, 0, 0),0);
        blackImage.gameObject.SetActive(true);
        blackImage.DOKill();
        blackImage.DOColor(new Color(0, 0, 0, 1), duration); }
    IEnumerator DestoryAndBlackFade()
    {
        yield return new WaitForSeconds(duration+0.1f);
        Destroy(ThingsAboutGame);
        IntroduceGameUI.SetActive(false);
        blackImage.DOKill();
        PlayerFollow.Priority = 11;
        blackImage.DOColor(new Color(0, 0, 0, 0), duration);
        
        
    }
}
