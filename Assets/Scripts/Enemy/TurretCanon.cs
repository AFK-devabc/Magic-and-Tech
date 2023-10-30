using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCanon : Enemy
{
    [Header("-------------ROTATION SPEED-----------------")]
    [SerializeField] float angularDeg = 0f;
    float degMax = 0f;
    float degMin = 0f;
    [SerializeField] float angularSpeed = 0f;
    float angularSpeedperFrame;
    int flagRight = 1;

    public override void Start()
    {
        base.Start();
        angle = transform.rotation.y * Mathf.Rad2Deg;
        degMax = angle + angularDeg;
        degMin = angle - angularDeg;
    }

    public override void Update()
    {
        angularSpeedperFrame = angularSpeed / (1.0f / Time.deltaTime);
        base.Update();
    }

    public override void SetTarget(Transform target)
    {
        isCombat = true;
        base.SetTarget(target);
    }

    public override void Move()
    {
        if(isCombat)
        {
            transform.LookAt(target);
        }
        else
        {
            angle = angle + angularSpeedperFrame * flagRight;
            if(angle >= degMax)
            {
                angle= degMax;
                flagRight = -1;
            }
            else if(angle <= degMin)
            {
                angle = degMin;
                flagRight = 1;
            }

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
