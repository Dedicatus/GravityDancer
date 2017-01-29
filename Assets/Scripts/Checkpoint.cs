using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public Transform spawnPos;
    public Vector3 spawnGravityDir;

	void Start () {
		
	}
	
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            GameContext.spawnPos = spawnPos.position;
            GameContext.spawnGravity = spawnGravityDir;
        }
    }
}
