using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHEBOT_MeleeAttack : AttackSkill
{
    [Header("----------------BULLET------------------")]
    [SerializeField] Bullet bulletFrefabs;
    [SerializeField] Transform FirePosition;

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
        Bullet bullet = Instantiate(bulletFrefabs, FirePosition.position, Quaternion.identity);
        enemy.angle = Mathf.Atan2(enemy.transform.forward.x, enemy.transform.forward.z) * Mathf.Rad2Deg;
        bullet.angle = enemy.angle;
        //Vector3 temp = enemy.GetTarget().position;
        //temp.y += 1;
        //bullet.velocity = (temp - FirePosition.position).normalized;
    }
}
