using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackSkill : MonoBehaviour
{
    [SerializeField] Enemy enemy;
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

    public virtual void StartAttack()
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
        if (enemy.GetTarget() != null)
        {
            if (isRange == true)
            {
                float x = Mathf.Abs(enemy.GetTarget().position.x - transform.position.x);
                if (x >= minRange && x <= maxRange)
                    isInRange = true;
                else isInRange = false;
            }
            else isInRange = true;
        }
    }
    public virtual void StopAttack()
    {

    }
    public abstract void Attack();
    public abstract void aniEvent();

}
