using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class UseGravity : MonoBehaviour {
    Rigidbody rbody;
	void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate()
    {
        GravityManager manager = GravityManager.Instance();
        if(manager != null)
            rbody.AddForce(manager.gravityDir * manager.gravityMagnitude);
    }
}
