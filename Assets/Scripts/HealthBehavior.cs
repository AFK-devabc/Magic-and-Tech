using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField] protected int maxHealthPoint;
    [SerializeField] protected int healthPoint;

    public virtual void TakeDamage(int damage)
    {
        this.healthPoint -= damage;
        if (this.healthPoint <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        this.gameObject.SetActive(false);


    }

    public bool IsDead()
    {
        return healthPoint <= 0;
    }

}
