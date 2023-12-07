using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHEBOT_MeleeAttack : AttackSkill
{
    [Header("----------------Shoot------------------")]
    [SerializeField] Transform firePosition;
    [SerializeField] ProjectileController projectile;

    private ProjectileManager projectileManager;
    public override void StartAttack()
    {
        base.StartAttack();
        enemy.ani.Play("Shebot_Rifle_fire");
    }

    public override void Attack()
    {
        enemy.transform.LookAt(enemy.GetTarget());
    }

    public override void StopAttack()
    {
        base.StopAttack();
        if(!isReady())
            enemy.ani.Play("Shebot_IDLE");
    }

    public override void aniEvent()
    {
        ProjectileController bullet = projectileManager.GetProjectile(projectile);

        bullet.transform.position = firePosition.position;

        bullet.transform.LookAt(new Vector3(enemy.GetTarget().position.x, firePosition.position.y, enemy.GetTarget().position.z));

    }
}
