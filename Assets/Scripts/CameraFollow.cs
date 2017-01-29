using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector3 cameraOffset;
    public GameObject followObject;

	void Start () {
        followObject = GameContext.player.gameObject;
	}
	
	void Update () {
        if(followObject == null || followObject.activeSelf == false)
        {
            if (GameContext.player != null) followObject = GameContext.player.gameObject;
            else return;
        }
        Transform follow = followObject.transform;
        Vector3 gravityDir = GravityManager.Instance().gravityDir;
        float degree = Vector3.Angle(Vector3.down, gravityDir);
        if (gravityDir.x < 0) degree = -degree;
        transform.rotation = Quaternion.Euler(0, 0, degree);
        //transform.LookAt(follow, -GravityManager.Instance().gravityDir);
        //transform.forward = follow.position - transform.position;
        //transform.up = -GravityManager.Instance().gravityDir;
        transform.position = follow.position + cameraOffset;
	}
}
