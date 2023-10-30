using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayObject
{
    [SerializeField] protected AttackSkill currentSkill;
    [SerializeField] protected List<AttackSkill> skills = new List<AttackSkill>();

    // Attack
    protected bool isCombat = false;

    public override void Update()
    {
        if (isDead) return;
        if (isAttack)
        {
            Attack();
        }

        if (isCombat == true && isAttack == false)
        {
            currentSkill = GetAttackSkill();
            if (currentSkill != null)
            {
                currentSkill.StartAttack();
                isAttack = true;
            }
        }
        base.Update();
    }

    public override void Attack()
    {
        base.Attack();
        if (currentSkill != null)
        {
            currentSkill.Attack();
        }
    }

    public virtual void StopAttack()
    {
        if (currentSkill != null)
        {
            currentSkill.StopAttack();
        }
    }

    public AttackSkill GetAttackSkill()
    {
        foreach (var skill in skills)
        {
            if (skill.isReady())
                return skill;
        }
        return null;
    }

    public virtual void AniEventAttack()
    {
        currentSkill.aniEvent();
    }

    public override void Dead()
    {
        base.Dead();
        Destroy(gameObject);
    }
}
