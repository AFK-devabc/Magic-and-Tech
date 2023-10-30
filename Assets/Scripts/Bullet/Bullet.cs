using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseObject
{
    public override void Move()
    {
        velocity.z = this.speed * Mathf.Cos((angle) * Mathf.Deg2Rad);
        velocity.x = this.speed * Mathf.Sin((angle) * Mathf.Deg2Rad);
        velocity.y = 0;
        this.transform.rotation = Quaternion.Euler(0, angle, 0);
        this.transform.position += velocity * Time.deltaTime;
        
    }
}
