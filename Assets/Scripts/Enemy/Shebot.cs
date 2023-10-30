using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shebot : Enemy
{
    [Header("------------MOVEMENT------------")]
    [SerializeField] List<Vector3> listDes = new List<Vector3>();
    public int indexDes = 0;

    [Header("------------SPEED---------------")]
    [SerializeField] float Speed_RUN;
    [SerializeField] float Speed_WALK;

    [Header("------------STATE_IDLE----------")]
    float TimeIDLEStart = 0f;
    [SerializeField] float TimeIDLE = 0f;

    public override void Start()
    {
        base.Start();
        velocity = (listDes[indexDes] - this.transform.position).normalized;
        speed = Speed_WALK;
    }

    public override void Update()
    {
        if (!isMove && isCombat==false)
        {
            if (TimeIDLEStart > TimeIDLE)
            {
                indexDes++;
                if (indexDes >= listDes.Count)
                {
                    indexDes = 0;
                }
                velocity = (listDes[indexDes] - this.transform.position).normalized;

                isMove = true;
            }
            else
            {
                TimeIDLEStart += Time.deltaTime;
            }
            ani.SetFloat("Speed", 0f);
        }
        base.Update();
    }

    public override void Move()
    {
        float enemySpeed = Mathf.Max(Mathf.Abs(velocity.x), Mathf.Abs(velocity.z)) > 0 ? speed : 0f;
        ani.SetFloat("Speed", enemySpeed);
        if (isCombat)
        {
            velocity = (target.position - this.transform.position).normalized;
        }
        else
        {
            Vector3 temp = this.transform.position;
            temp.y = 0f;
            if (Vector3.Distance(listDes[indexDes], temp) <= 0.1f)
            {
                this.transform.position = listDes[indexDes];
                isMove = false;
                TimeIDLEStart = 0f;
            }
        }
        
        base.Move();
    }

    public override void SetTarget(Transform target)
    {
        isCombat = true;
        speed = Speed_RUN;
        base.SetTarget(target);
    }
}
