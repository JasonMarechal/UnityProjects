using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Int2 {

	public int FX, FZ;

	public Int2(int parX, int parZ){
		this.FX = parX;
		this.FZ = parZ;
	}

	public static Int2 operator + (Int2 parA, Int2 parB) {
		return new Int2 (parA.FX + parB.FX, parA.FZ + parB.FZ);
	}
}
