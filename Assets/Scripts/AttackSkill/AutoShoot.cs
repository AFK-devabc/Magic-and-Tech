using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AutoShoot : AttackSkill
{

    [Header("----------------Shoot------------------")]
    [SerializeField] Transform firePosition;
    [SerializeField] ProjectileController projectile;

    private ProjectileManager projectileManager;

    private void Start()
    {
        projectileManager = ProjectileManager.GetInstance();
    }

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
        ProjectileController bullet = projectileManager.GetProjectile(projectile);

        bullet.transform.position = firePosition.position;

        bullet.transform.LookAt(new Vector3( enemy.GetTarget().position.x, firePosition.position.y, enemy.GetTarget().position.z));

    }
}