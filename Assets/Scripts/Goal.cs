using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public float rotateRate;
    public GameObject text;
	void Start () {
		
	}

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.gameObject.SetActive(false);
            GetComponent<CreatePrefabAtPosition>().createPrefabAtPosition(col.gameObject.transform.position);
            text.SetActive(true);
        }
    }

    void Update()
    {
        transform.Rotate(0, rotateRate * Time.deltaTime, 0);
    }
}
