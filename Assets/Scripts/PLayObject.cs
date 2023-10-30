using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObject : BaseObject
{
    [SerializeField] protected int maxHP;
    [SerializeField] protected int HP;
    public bool isAttack;
    public bool isDead;

    public virtual void Attack()
    {

    }

    public virtual void TakeDamage(int damage)
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
