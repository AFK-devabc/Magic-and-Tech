using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PLayObject
{
    AttackSkill currentSkill;
    List<AttackSkill> skills = new List<AttackSkill>();

    public AttackSkill GetAttackSkill()
    {
        return null;
    }
}
