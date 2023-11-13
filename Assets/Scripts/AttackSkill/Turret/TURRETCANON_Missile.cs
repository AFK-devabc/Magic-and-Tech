using FORGE3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TURRETCANON_Missile : AttackSkill
{
    [Header("----------------MISSILE------------------")]
    //[SerializeField] F3DMissile missileFrefabs;
    //[SerializeField] Transform FirePosition;
    [SerializeField] ProjectileController projectile;

    public override void StartAttack()
    {
        base.StartAttack();
        enemy.ani.SetTrigger("Shoot");
    }

    public override void Attack()
    {
        
    }

    public override void StopAttack()
    {
        base.StopAttack();
        if (!isReady())
            enemy.ani.Play("Idle");
    }

    public override void aniEvent()
    {
    }
}
