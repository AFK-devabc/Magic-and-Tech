using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROYROBOT_MeleeAttack02 : AttackSkill
{
    [Header("----------------BULLET------------------")]
    [SerializeField] Bullet bulletFrefabs;
    [SerializeField] float angularDeg = 0f;
    [SerializeField] Transform FirePosition;

    public override void StartAttack()
    {
        base.StartAttack();
        enemy.ani.Play("Attack2");
    }

    public override void Attack()
    {
        enemy.transform.LookAt(enemy.GetTarget());
    }

    public override void StopAttack()
    {
        base.StopAttack();
        if (!isReady())
            enemy.ani.Play("Idle");
    }

    public override void aniEvent()
    {
        enemy.angle = Mathf.Atan2(enemy.transform.forward.x, enemy.transform.forward.z) * Mathf.Rad2Deg;

        Bullet bullet = Instantiate(bulletFrefabs, FirePosition.position, Quaternion.identity);
        bullet.angle = enemy.angle + Random.Range(-angularDeg, angularDeg);

        Destroy(bullet, 3f);
    }
}
