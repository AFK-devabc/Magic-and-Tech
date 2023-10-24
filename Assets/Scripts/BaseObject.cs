using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [Header("----------------INFO------------------")]
    [SerializeField] protected int damage;
    [SerializeField] protected int speed;
    [SerializeField] protected float angle;
    [SerializeField] protected Transform target;
    [SerializeField] protected int state;

    [Header("--------------COMPONENT---------------")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Animator ani;

    public Vector3 velocity;
    public bool isMove;
    // Start is called before the first frame update
    public virtual void Start()
    {
        velocity = Vector3.zero;
        angle = 0;  
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        if(velocity != Vector3.zero)
        {
            this.angle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        this.transform.position = this.transform.position + this.velocity * speed * Time.deltaTime;
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;   
    }

    public virtual Transform GetTarget()
    {
        return target;
    }

    public virtual void changeState(int state)
    {
        this.state = state;
    }
}
