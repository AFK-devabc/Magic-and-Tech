using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    [SerializeField] private AttackBehavior attackBehavior;

    public void AnimationTriggerAttack()
    {
        attackBehavior.AniEventAttack();
    }

    public void AnimationStopAttack()
    {
        attackBehavior.StopAttack();
    }

}
