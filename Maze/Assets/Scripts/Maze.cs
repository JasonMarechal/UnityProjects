using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
	public int FSizeX, FSizeZ;
	public MazeCell FCellPrefab;
	private MazeCell[,] FCells;
}