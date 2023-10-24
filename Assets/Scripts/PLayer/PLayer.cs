using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : PLayObject
{
    public override void Update()
    {
        base.Update();

        ani.SetFloat("Speed", (Mathf.Abs(velocity.x) > 0 || Mathf.Abs(velocity.z) > 0) ? 1 : 0);
    }
    public override void changeState(int state)
    {
        base.changeState(state);
        Vector3 temp = velocity;
        switch (state)
        {
            case (int)STATE_PLAYER.IDLE:
                break;
            case (int)STATE_PLAYER.X_RELEASE:
                temp.x = 0;
                velocity = temp;
                break;
            case (int)STATE_PLAYER.Z_RELEASE:
                temp.z = 0;
                velocity = temp;
                break;
            case (int)STATE_PLAYER.RUN_LEFT:
                temp.x = -1;
                velocity = temp;
                break;
            case (int)STATE_PLAYER.RUN_RIGHT:
                temp.x = 1;
                velocity = temp;
                break;
            case (int)STATE_PLAYER.RUN_UP:
                temp.z = 1;
                velocity = temp;
                break;
            case (int)STATE_PLAYER.RUN_DOWN:
                temp.z = -1;
                velocity = temp;
                break;
        }
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
