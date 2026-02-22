using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GongjiangMoveAfterIntroduce : MonoBehaviour
{
    public Transform GongjiangStart;
    public GameObject Player;
    public GameObject Gongjiang;
    public Transform[] wayPoint;
    public int PointIndex;
    public float MoveSpeed;
    public bool isGongjiangMoving;
    void Start()
    {
        Gongjiang.transform.position = GongjiangStart.transform.position;
        Gongjiang.GetComponent<Animator>().Play("walk");
    }

    // Update is called once per frame
    void Update()
    {
        if (PointIndex < wayPoint.Length)
        {
            
            if (Vector3.Distance(Gongjiang.transform.position, wayPoint[PointIndex].transform.position) > 0.5f)
            {
                MoveTarget(Gongjiang.transform, wayPoint[PointIndex].transform, ref isGongjiangMoving);
            }
            else if (Vector3.Distance(Gongjiang.transform.position, wayPoint[PointIndex].transform.position) <=0.5f)
            { PointIndex++; }

        }
        if (PointIndex == wayPoint.Length)
        { Gongjiang.GetComponent<Animator>().Play("Idle"); }
    }
    private void MoveTarget(Transform target, Transform endPoint, ref bool isMoving)
    {
        // 匀速移动到终点
        target.position = Vector3.MoveTowards(
            target.position,
            endPoint.position,
            MoveSpeed * Time.deltaTime
        );

    }
}
