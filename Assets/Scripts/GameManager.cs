using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	[HideInInspector]
	public Player player;

	public void RestartAfterDelay(float delay)
    {
        resetGameContext();
        StartCoroutine(restartAfterDelay(delay));
	}

	IEnumerator restartAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void resetGameContext()
	{
		GameContext.player = null;
	}


	void StartGame()
	{
        if (GameContext.spawnPos == Vector3.zero)
            player = Instantiate(playerPrefab, playerSpawnPosition).GetComponent<Player>();
        else
        {
            player = Instantiate(playerPrefab).GetComponent<Player>();
            player.gameObject.transform.position = GameContext.spawnPos;
        }
        GameContext.player = player;
		
	}

	void Awake()
	{
		gameObject.AddComponent<TimeManager>();
		gameObject.AddComponent<GravityManager>();
		StartGame();
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
