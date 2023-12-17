using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRONEROBOT_Explode : AttackSkill
{
    [Header("----------------EXPLODE------------------")]
    [SerializeField] GameObject ShockWaveFrefab;
    [SerializeField] GameObject ShockWaveExplodeFrefab;
    [SerializeField] float timeExplode;
    float timeStart = 0f;

    GameObject shockwave;
    public override void StartAttack()
    {
        //if(enemy.isDead) return;    

        base.StartAttack();
        //enemy.ani.Play("DroneRbAttack");
        shockwave = Instantiate(ShockWaveFrefab, this.transform.position, Quaternion.identity);
        
        timeStart = 0f;
    }

    public override void Attack()
    {
        if (timeStart > timeExplode)
        {
            StopAttack();
        }
        else timeStart += Time.deltaTime;
    }

    public override void StopAttack()
    {
        base.StopAttack();
        Destroy(shockwave);
        GameObject obj = Instantiate(ShockWaveExplodeFrefab, this.transform.position, Quaternion.identity);
        Destroy(obj.gameObject, 2f);
        //enemy.Dead();
    }

    public override void aniEvent()
    {
        
    }
}
