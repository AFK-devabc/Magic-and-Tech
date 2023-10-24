using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayObject : BaseObject
{
    [SerializeField] protected int MaxHP;
    [SerializeField] protected int HP;
    protected bool isAttack;
    protected bool isDead;

    public virtual void Attack()
    {

    }

    public virtual void takeDamage(int damage)
    {
        this.HP -= damage;
        if(this.HP <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        this.isDead = true;
    }
}
