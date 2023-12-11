using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private AttackBehavior attackBehavior;
    [SerializeField] private HealthBehavior healthBehavior;

   [HideInInspector] public UnityEvent<Transform> SetTargetEvent;

    private void Awake()
    {
        SetTargetEvent = new UnityEvent<Transform>();
    }

    private void Start()
    {
        SetTargetEvent.AddListener(SetTarget);
    }

    private void OnEnable()
    {
        SetTargetEvent.Invoke(this.transform);
    }

    private void SetTarget(Transform target)
    {
        Debug.Log(target);
    }
}
