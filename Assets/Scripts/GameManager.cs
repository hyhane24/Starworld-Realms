using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameManager : MonoBehaviour
{
	public Maze mazePrefab;
	private Maze _mazeInstance;
	public GameObject alienPrefab;
	private GameObject alien;
	void Start()
	{
		BeginGame();
	}

	void Update()
	{
		//remove for hot reloading maze
		/* if (Input.GetKeyDown(KeyCode.R))
		{
			RestartGame();
		} */
	}

	private void BeginGame()
	{
		// _mazeInstance = PrefabUtility.InstantiatePrefab(mazePrefab) as Maze;
		_mazeInstance = Instantiate(mazePrefab) as Maze;
		if (_mazeInstance == null)
        {
			Debug.Log("Maze failed to generate");
        }
		_mazeInstance.Generate();

		// alien = Instantiate(alienPrefab, new Vector3(9.5f*5f,5f , -9.5f * 5f) , Quaternion.identity);

	}

	private void RestartGame()
	{
		Destroy(_mazeInstance.gameObject);
		BeginGame();
	}
}

