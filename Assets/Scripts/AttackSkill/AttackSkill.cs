using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackSkill : MonoBehaviour
{
    [SerializeField] protected Enemy enemy;
    [Header("---------------INFO ATTACK SKILL----------------")]
    [SerializeField] protected float damage;
    protected bool isCountDown;
    protected bool isInRange;
    [SerializeField] protected float duration;
    [SerializeField] protected float CD;
    protected float timeCDStart;
    [SerializeField] protected bool isRange;
    [SerializeField] protected float maxRange;
    [SerializeField] protected float minRange;
    [SerializeField] protected bool isStopMove;

    private Transform target;

    protected int aniEventCount;

    public virtual void Update()
    {
        if (isCountDown == false)
        {
            if (timeCDStart > CD)
            {
                isCountDown = true;
                timeCDStart = 0f;
            }
            else timeCDStart += Time.deltaTime;
        }

        // is In range
        if (target != null)
        {
            if (isRange == true)
            {
                float dis = Vector3.Distance(target.position , transform.position);
                if (dis >= minRange && dis <= maxRange)
                    isInRange = true;
                else isInRange = false;
            }
            else isInRange = true;
        }
    }

    public virtual void StartAttack()
    {
        if (isStopMove)
            enemy.isMove = false;
    }

    public virtual void StopAttack()
    {
        enemy.isAttack = false;
        if (isStopMove)
            enemy.isMove = true;
        if (CD != 0)
        {
            isCountDown = false;
            timeCDStart = 0f;
        }
    }

    public abstract void Attack();
    public abstract void aniEvent();

    public virtual bool isReady()
    {
        if (isCountDown && isInRange)
            return true;
        return false;
    }
}
