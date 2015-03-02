using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze FMazePrefab;

	private Maze FMazeInstance;
	
	private void Start () {
		BeginGame();
	}
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}
	
	private void BeginGame () {
		FMazeInstance = Instantiate (FMazePrefab) as Maze;
		FMazeInstance.Generate ();
	}
	
	private void RestartGame () {
		Destroy (FMazeInstance.gameObject);
		BeginGame ();
	}
}