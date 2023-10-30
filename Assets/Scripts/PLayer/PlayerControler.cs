using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private static PlayerControler instance;

    public static PlayerControler getInstance()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType<PlayerControler>();
        }

        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] Player player;

    private void Update()
    {
        if(player != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.changeState((int)STATE_PLAYER.RUN_LEFT);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                player.changeState((int)STATE_PLAYER.RUN_RIGHT);
            }
            else player.changeState((int)STATE_PLAYER.X_RELEASE);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                player.changeState((int)STATE_PLAYER.RUN_UP);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                player.changeState((int)STATE_PLAYER.RUN_DOWN);
            }
            else player.changeState((int)STATE_PLAYER.Z_RELEASE);

        }
    }
}
