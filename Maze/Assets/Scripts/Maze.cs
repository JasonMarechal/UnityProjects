using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
	public int FSizeX, FSizeZ;
	public MazeCell FCellPrefab;
	private MazeCell[,] FCells;

	public void Generate() {
		FCells = new MazeCell[FSizeX, FSizeZ];
		for (int x = 0; x < FSizeX; ++x) {
			for (int z = 0; z < FSizeZ; ++z) {
				CreateCell(x, z);
			}
		}
	}

	void CreateCell (int parX, int parZ)
	{
		MazeCell newCell = Instantiate (FCellPrefab) as MazeCell;
		FCells [parX, parZ] = newCell;
		newCell.name = "Maze Cell " + parX + ", " + parZ;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3 (parX - FSizeX * 0.5f + 0.5f, 0.0f, parZ - FSizeZ * 0.5f + 0.5f);
	}
}