using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnContact : MonoBehaviour {

	bool triggered = false;

	void Start () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player" && triggered == false)
		{
			col.gameObject.SetActive(false);
			triggered = true;
            GetComponent<CreatePrefabAtPosition>().createPrefabAtPosition(col.gameObject.transform.position);
			GameManager.Instance().RestartAfterDelay(3.0f);
		}
	}
}
