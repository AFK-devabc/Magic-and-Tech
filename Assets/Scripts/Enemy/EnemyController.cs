using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public EnemyMovement movement;
    [SerializeField] public AttackBehavior attackBehavior;
    [SerializeField] public HealthBehavior healthBehavior;

    [HideInInspector] public UnityEvent<Transform> SetTargetEvent;

    private void Awake()
    {
        SetTargetEvent = new UnityEvent<Transform>();
    }

    private void Start()
    {
        if (attackBehavior)
            SetTargetEvent.AddListener(attackBehavior.SetTarget);
        if (movement)
            SetTargetEvent.AddListener(movement.SetTarget);
    }
}
