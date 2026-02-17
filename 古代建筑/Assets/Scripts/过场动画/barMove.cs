using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class barMove : MonoBehaviour
{
    public RectTransform TopBar;
    public RectTransform BottomBar;
    public float duration;
    void Start()
    {
        TopBar.DOKill();
        BottomBar.DOKill();
       BarAppear();
    }
    private void OnEnable()
    {
        Event.Instance.BarDisappearAct += BarDisappear;
    }
    private void OnDisable()
    {
        Event.Instance.BarDisappearAct -= BarDisappear;
    }
    void BarAppear()
    {
        TopBar.DOAnchorPosY(0, duration);
        BottomBar.DOAnchorPosY(0,duration);
    }
    void BarDisappear()
    { TopBar.DOAnchorPosY(90, duration);
    BottomBar.DOAnchorPosY(-59,duration);}
}
