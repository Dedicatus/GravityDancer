using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour {

    enum PlayerState
    {
        Walk,
        Jump
    }

    PlayerState playerState;

    public float walkForce;
    public float jumpForce;
    public float jumpImpulse;
    public float jumpDelay;

    [HideInInspector]
    public bool canJump;
    Rigidbody rbody;

	void Start () {
        playerState = PlayerState.Jump;
        rbody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        HandleInput();
	}

    void HandleInput()
    {
        if (PlayerState.Jump == playerState)
        {
            walkLeftRight();
        }
        else if (PlayerState.Walk == playerState)
        {
            walkLeftRight();
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                jump();
            }
        }
    }

    void jump()
    {
        rbody.AddForce(0, jumpImpulse, 0, ForceMode.Impulse);
    }

    void walkLeftRight()
    {
        bool getW = Input.GetKey(KeyCode.W), getD = Input.GetKey(KeyCode.D);
        //if not pressing both
        if (getW != getD)
        {
            if (getW)
            {
                rbody.AddForce(-walkForce, 0, 0);
            }
            else
            {
                rbody.AddForce(walkForce, 0, 0);
            }
        }
    }

}
