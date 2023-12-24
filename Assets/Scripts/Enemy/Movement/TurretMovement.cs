using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TurretMovement : MovementBehavior
{

    [Header("-------------ROTATION SPEED-----------------")]
    [SerializeField] float angularDeg = 0f;
    float degMax = 0f;
    float degMin = 0f;
    [SerializeField] float angularSpeed = 0f;
    float angularSpeedperFrame;
    int flagRight = 1;
    [SerializeField] public float angle = 0;

    private void Start()
    {
        angle = transform.rotation.y * Mathf.Rad2Deg;
        degMax = angle + angularDeg;
        degMin = angle - angularDeg;
    }


    public override void Move(NavMeshAgent agent, Transform posi, Transform desPosi)
    {
        angularSpeedperFrame = angularSpeed / (1.0f / Time.deltaTime);

            angle = angle + angularSpeedperFrame * flagRight;
            if (angle <= degMax)
            {
                angle = degMax;
                flagRight = -1;
            }
            else if (angle >= degMin)
            {
                angle = degMin;
                flagRight = 1;
            }

            posi.Rotate(0f, angularSpeedperFrame * flagRight, 0f);

    }


}