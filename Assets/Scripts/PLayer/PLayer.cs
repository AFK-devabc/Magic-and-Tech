using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayObject
{

    [Header("---------- Movement ----------")]
    //[SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform pointToLook;


    [Header("---------- Dash ----------")]

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCD;
    [SerializeField] private LayerMask hitMask;

    private Vector2 dashVelocity;
    private bool isDashing = false;
    private bool canDash = true;

    public override void Update()
    {
        ani.SetFloat("Speed", velocity.magnitude);
        LookAtMouse();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = new Vector3(dashVelocity.x, rb.velocity.y, dashVelocity.y);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, rb.velocity.normalized, out hit, rb.velocity.magnitude * Time.fixedDeltaTime, hitMask)) ;
            {
                if (hit.collider)
                {
                    transform.position = hit.point;
                    dashVelocity = Vector2.zero;
                }
            }

        }
        else
        {
            rb.velocity = velocity;
        }

    }
    public override void Move()
    {
        
    }
    public override void changeState(int state)
    {
        base.changeState(state);
        switch (state)
        {
            case (int)STATE_PLAYER.IDLE:
                break;
        }
    }

    public void ReadMovemntValue(InputAction.CallbackContext context)
    {
        Vector2 temp =  context.ReadValue<Vector2>() * speed;
        velocity.x = temp.x;
        velocity.z = temp.y;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (canDash)
        {
            dashVelocity = dashSpeed * (  new Vector2( velocity.x, velocity.z) != Vector2.zero ? new Vector2(velocity.x, velocity.z).normalized
                : new Vector2(transform.forward.x, transform.forward.z).normalized);
            StartCoroutine(DashCooldown());
        }
    }
    private void LookAtMouse()
    {
        transform.LookAt(new Vector3(pointToLook.position.x, transform.position.y, pointToLook.position.z));
    }
    private IEnumerator DashCooldown()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }

}


public enum STATE_PLAYER
{
    IDLE = 0,
    RUN_LEFT = 1,
    RUN_RIGHT = 2,
    X_RELEASE =3,
    RUN_UP = 4,
    RUN_DOWN = 5,
    Z_RELEASE = 6
}
