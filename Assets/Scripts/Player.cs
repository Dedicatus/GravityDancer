using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour {

    public enum PlayerState
    {
        Wait,
        Walk,
        Jump
    }

    public PlayerState playerState;

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
        transform.parent = null;
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

	void Update ()
    {
        Vector3 gravityDir = GravityManager.Instance().gravityDir;
        float degree = Vector3.Angle(Vector3.down, gravityDir);
        if (gravityDir.x < 0) degree = -degree;
        transform.rotation = Quaternion.Euler(0, 0, degree);
        HandleInput();
	}
    
    void HandleInput()
    {
        if (PlayerState.Jump == playerState)
        {
            walkLeftRight();
            if(GetJumpKey() && TimeManager.Instance().timeDictionary.ContainsKey("jumpDelay"))
            {
                Vector3 gravityDir = GravityManager.Instance().gravityDir;
                rbody.AddForce(gravityDir * -jumpForce);
            }
        }
        else if (PlayerState.Walk == playerState)
        {
            walkLeftRight();
            if(GetJumpKeyDown())
            {
                jump();
            }
        }
    }

    bool GetJumpKey()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
    }

    bool GetJumpKeyDown()
    {
        return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space);
    }

    void jump()
    {
        Vector3 gravityDir = GravityManager.Instance().gravityDir;
        rbody.AddForce(gravityDir * -jumpImpulse, ForceMode.Impulse);
        //playerState = PlayerState.Jump;
        TimeManager.Instance().timeDictionary["jumpDelay"] = jumpDelay;
    }

    void walkLeftRight()
    {
        bool getA = Input.GetKey(KeyCode.A), getD = Input.GetKey(KeyCode.D);
        Vector3 gravityDir = GravityManager.Instance().gravityDir;
        //if not pressing both
        if (getA != getD)
        {
            if (getA)
            {
                rbody.AddForce(Vector3.Cross(gravityDir,Vector3.forward)*walkForce);
            }
            else
            {
                rbody.AddForce(Vector3.Cross(gravityDir, Vector3.forward) * -walkForce);
            }
        }
    }

}
