using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;

    public static GameManager Instance()
    {
        if(_instance == null)
        {
            GameObject obj = new GameObject();
            _instance = obj.AddComponent<GameManager>();
        }
        return _instance;
    }

    public GameObject playerPrefab;
    public Transform playerSpawnPosition;

    Player player;

    void StartGame()
    {
        player = Instantiate(playerPrefab, playerSpawnPosition).GetComponent<Player>();

    }

	void Start () {
        gameObject.AddComponent<TimeManager>();
        StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
