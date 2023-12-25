using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform forward;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private Animator animator;
    private ProjectileManager projectileManager;
    private bool canExcuteAttack;


    private void Start()
    {
        projectileManager = ProjectileManager.GetInstance();
        OnWeaponEquip();
        canExcuteAttack = true;
    }

    public void ExcuteAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canExcuteAttack)
        {
            ProjectileController bullet = projectileManager.GetProjectile(weapon.projectilePrefab);

            bullet.transform.forward = new Vector3( forward.forward.x, 0, forward.forward.z);
            bullet.transform.position = shootPoint.position;

            StartCoroutine(AttackCountdown());
        }
    }

    private IEnumerator AttackCountdown()
    {
        canExcuteAttack = false;
        yield return new WaitForSeconds(weapon.cooldownTime);
        canExcuteAttack = true;
    }

    public void EquipWeapon( Weapon weapon)
    {
        this.weapon = weapon;
    }

    private void OnWeaponEquip()
    {
        for (var i = weaponHolder.childCount - 1; i >= 0; i--)
        {
            // only destroy tagged object
                Destroy(weaponHolder.GetChild(i).gameObject);
        }

        GameObject newWeapon = Instantiate(weapon.weaponPrefab,weaponHolder);
    }
}
