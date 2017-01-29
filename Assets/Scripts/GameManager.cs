using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;

    public static GameManager Instance()
    {
        if(_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
