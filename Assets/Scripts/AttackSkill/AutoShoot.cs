using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AutoShoot : AttackSkill
{

    [Header("----------------Shoot------------------")]
    [SerializeField] Transform firePosition;
    [SerializeField] ProjectileController projectile;

    private ProjectileManager projectileManager;
    [SerializeField] private Animator animator;
    [SerializeField] LayerMask obstacleLayer;

    [SerializeField] private string attackAni;

    private void Start()
    {
        projectileManager = ProjectileManager.GetInstance();
    }

    public override void StartAttack()
    {
        base.StartAttack();
        animator.Play(attackAni);
    }

    public override void Attack()
    {

    }
    public override bool CanAttack()
    {
        Vector3 direction = target.position - firePosition.position;
        direction.y = 0;
        bool canattack = Physics.Raycast(firePosition.position - new Vector3(0, firePosition.position.y, 0)
            , direction, direction.magnitude, obstacleLayer);
        return !canattack;
    }
    public override void aniEvent()
    {
        ProjectileController bullet = projectileManager.GetProjectile(projectile);

        bullet.transform.position = firePosition.position;

        bullet.transform.LookAt(new Vector3(target.position.x, firePosition.position.y, target.position.z));
    }
}