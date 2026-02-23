using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor.Rendering.LookDev;


public class 主角与工匠移动 : MonoBehaviour
{
    [Header("角色引用")]
    public Transform Player;          // 主角Transform
    public Transform gongjiang;       // 工匠Transform

    [Header("主角移动点位")]
    public Transform PlayerStart;     // 主角起始点
    public Transform PlayerEnd;       // 主角终点

    [Header("工匠移动点位")]
    public Transform gongjiangStart;  // 工匠起始点
    public Transform gongjiangEnd;    // 工匠终点

    [Header("移动配置")]
    public float MoveSpeed = 2f;      // 移动速度（米/秒）
    public bool AutoMoveOnStart = true; // 是否游戏开始自动移动

    [Header("动画控制器")]
    public Animator playeranimation;  // 主角动画
    public Animator gongjianganimation; // 工匠动画

   
    private bool isPlayerMoving = false;
    private bool isGongjiangMoving = false;

    public float fadeDuration=2f;
    public Image blackImage;

    private void Start()
    {

        if (blackImage != null)
        {
            blackImage.color = new Color(0, 0, 0, 1);
            
            Fade();
        }
        if (!CheckReferences())
        {
            Debug.LogError("关键引用缺失，移动功能将无法正常工作！");
            return;
        }

      
        ResetAllToStartPoint();

        // 如果开启自动移动，游戏开始即启动移动
        if (AutoMoveOnStart)
        {
            StartAllMove();
        }

    }

    private void Update()
    {
        // 只有在移动状态下才执行移动逻辑
        if (isPlayerMoving)
        {
            MoveTarget(Player, PlayerEnd, ref isPlayerMoving);
        }

        if (isGongjiangMoving)
        {
            MoveTarget(gongjiang, gongjiangEnd, ref isGongjiangMoving);
        }
    }

    /// <summary>
    /// 通用移动方法：处理单个目标的匀速移动
    /// </summary>
    /// <param name="target">要移动的目标物体</param>
    /// <param name="endPoint">目标终点</param>
    /// <param name="isMoving">移动状态标记（引用传递）</param>
    private void MoveTarget(Transform target, Transform endPoint, ref bool isMoving)
    {
        // 匀速移动到终点
        target.position = Vector3.MoveTowards(
            target.position,
            endPoint.position,
            MoveSpeed * Time.deltaTime
        );

       
        if (Vector3.Distance(target.position, endPoint.position) < 0.5f)
        {
           
          
            isMoving = false;

           
            if (target == Player && playeranimation != null)
            {
                playeranimation.SetBool("isAnimation", false);
            }
            else if (target == gongjiang && gongjianganimation != null)
            {
                gongjianganimation.Play("Idle");
               
            }
        }
    }


    private bool CheckReferences()
    {
        bool isAllValid = true;

        if (Player == null) { Debug.LogError("Player引用未赋值！"); isAllValid = false; }
        if (gongjiang == null) { Debug.LogError("gongjiang引用未赋值！"); isAllValid = false; }
        if (PlayerStart == null) { Debug.LogError("PlayerStart引用未赋值！"); isAllValid = false; }
        if (PlayerEnd == null) { Debug.LogError("PlayerEnd引用未赋值！"); isAllValid = false; }
        if (gongjiangStart == null) { Debug.LogError("gongjiangStart引用未赋值！"); isAllValid = false; }
        if (gongjiangEnd == null) { Debug.LogError("gongjiangEnd引用未赋值！"); isAllValid = false; }

        return isAllValid;
    }


    public void ResetAllToStartPoint()
    {
        if (Player != null && PlayerStart != null)
        {
            Player.position = PlayerStart.position;
            isPlayerMoving = false;
        }

        if (gongjiang != null && gongjiangStart != null)
        {
            gongjiang.position = gongjiangStart.position;
            isGongjiangMoving = false;
        }
    }

    public void StartAllMove()
    {
        if (CheckReferences())
        {
            isPlayerMoving = true;
            isGongjiangMoving = true;
            playeranimation.SetBool("isAnimation", true);

            if (playeranimation != null)
            {
                playeranimation.Play("walk1");
            }
            if (gongjianganimation != null)
            {
                gongjianganimation.Play("walk");
            }
        }
    }

  
    public void StopAllMove()
    {
        isPlayerMoving = false;
        isGongjiangMoving = false;
        playeranimation.SetBool("isAnimation", false);

        if (playeranimation != null)
        {
           
        }
        if (gongjianganimation != null)
        {
            
        }
    }

    
    public void Move()
    {
        StartAllMove();
    }
    void TurnBack()
    {
        gongjiang.transform.localScale = new Vector3(math.abs(gongjiang.transform.localScale.x), gongjiang.transform.localScale.y, gongjiang.transform.localScale.z);
       
    }
    void Fade()
    {
        blackImage.DOKill();
        blackImage.gameObject.SetActive(true);
        blackImage.DOColor(new Color(0, 0, 0, 0), fadeDuration);

    }
    private void OnDisable()
    {
        Event.Instance.CallBarDisappear();
    }
}
