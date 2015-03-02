using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
	public Int2 FSize;
	public MazeCell FCellPrefab;
	private MazeCell[,] FCells;
	public float FGenerationStepDelay;

	public IEnumerator Generate() {
		WaitForSeconds delay = new WaitForSeconds (FGenerationStepDelay);
		FCells = new MazeCell[FSize.FX, FSize.FZ];
		for (int x = 0; x < FSize.FX; ++x) {
			for (int z = 0; z < FSize.FZ; ++z) {
				yield return delay;
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
		newCell.transform.localPosition = new Vector3 (parX - FSize.FX * 0.5f + 0.5f, 0.0f, parZ - FSize.FZ * 0.5f + 0.5f);
	}
}