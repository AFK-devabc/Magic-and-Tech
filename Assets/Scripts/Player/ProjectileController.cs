using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] public ProjectileStats projectileStats;
    [SerializeField] private ParticleSystem hitEffect;  
    protected Action<ProjectileController> _killAction;

    public void InIt(Action<ProjectileController> killAction)
    {
        _killAction = killAction;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position , transform.forward, out hit, projectileStats.movSpeed * Time.fixedDeltaTime , projectileStats.hitMask)) 
        {
            if (hit.collider != null)
            {
                Debug.Log("hit");
                _killAction(this);
                transform.position = hit.point;
                hitEffect.Play();
                DoDamage(hit);
            }
        }
        else 
        {
            transform.position += projectileStats.movSpeed * Time.fixedDeltaTime * transform.forward;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+ transform.forward * projectileStats.movSpeed * Time.fixedDeltaTime);
    }
    protected void DoDamage(RaycastHit hit)
    {
        hit.transform.GetComponent<PlayObject>()?.TakeDamage(projectileStats.damage);
    }
}
