using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROYROBOT_MeleeAttack02 : AttackSkill
{
    [Header("----------------BULLET------------------")]
    [SerializeField] ProjectileController bulletPrefab;
    [SerializeField] float angularDeg = 0f;
    [SerializeField] Transform FirePosition;

    private ProjectileManager projectileManager;

    private void Start()
    {
        projectileManager = ProjectileManager.GetInstance();
    }

    public override void StartAttack()
    {
        base.StartAttack();
        //enemy.ani.Play("Attack2");
    }

    public override void Attack()
    {
        //enemy.transform.LookAt(enemy.GetTarget());
    }

    public override void StopAttack()
    {
        //base.StopAttack();
        //if (!isReady())
        //    enemy.ani.Play("Idle");
    }

    public override void aniEvent()
    {
        //enemy.angle = Mathf.Atan2(enemy.transform.forward.x, enemy.transform.forward.z) * Mathf.Rad2Deg;

        //ProjectileController bullet = projectileManager.GetProjectile(bulletPrefab);

        //bullet.transform.position = FirePosition.position;

        //bullet.transform.LookAt(enemy.GetTarget());

    }
}
