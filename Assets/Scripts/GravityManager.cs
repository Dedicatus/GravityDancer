using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

    private static GravityManager _instance = null;

    public static GravityManager Instance()
    {
        return _instance;
    }

    public float gravityMagnitude = 50.0f;
    public float gravityChangeRate = 7.0f; //Change rate In radian

    //[HideInInspector]
    public List<Rigidbody> gravityList;

    //[HideInInspector]
    public Vector3 gravityDir;
    [HideInInspector]
    public Vector3 targetGravityDir;

    void Start()
    {
        _instance = this;
        if (GameContext.spawnGravity == Vector3.zero)
            gravityDir = new Vector3(0, -1, 0);
        else
            gravityDir = GameContext.spawnGravity.normalized;
        targetGravityDir = gravityDir;
    }

    void Update()
    {
        if(gravityDir != targetGravityDir)
        {
            gravityDir = Vector3.RotateTowards(gravityDir, targetGravityDir, gravityChangeRate * Time.deltaTime, 0);
            //print(targetGravityDir);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            targetGravityDir = Vector3.Cross(targetGravityDir, Vector3.forward).normalized;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            targetGravityDir = Vector3.Cross(targetGravityDir, Vector3.back).normalized;
        }
    }
    
}
