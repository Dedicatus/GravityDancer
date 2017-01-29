using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour {

    enum PlayerState
    {
        Wait,
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
	
    public void Grounded()
    {
        playerState = PlayerState.Walk;
    }

    public void NotGrounded()
    {
        playerState = PlayerState.Jump;
    }

    public void StartGame()
    {

    }

	void Update () {
        HandleInput();
	}
    
    void HandleInput()
    {
        if (PlayerState.Jump == playerState)
        {
            walkLeftRight();
            if(GetJumpKey() && TimeManager.Instance().timeDictionary.ContainsKey("jumpDelay"))
            {
                rbody.AddForce(0, jumpForce, 0);
            }
        }
        else if (PlayerState.Walk == playerState)
        {
            walkLeftRight();
            if(GetJumpKey())
            {
                jump();
            }
        }
    }

    bool GetJumpKey()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
    }

    void jump()
    {
        rbody.AddForce(0, jumpImpulse, 0, ForceMode.Impulse);
        playerState = PlayerState.Jump;
        TimeManager.Instance().timeDictionary["jumpDelay"] = jumpDelay;
    }

    void walkLeftRight()
    {
        bool getA = Input.GetKey(KeyCode.A), getD = Input.GetKey(KeyCode.D);
        //if not pressing both
        if (getA != getD)
        {
            if (getA)
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
