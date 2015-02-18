using UnityEngine;
using System.Collections;



public class Fractal : MonoBehaviour {


	public int FMaxDepth;
	public Mesh FMesh;
	public Material FMaterial;
	public float FChildScale;
	private int FDepth;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter> ().mesh = FMesh;
		gameObject.AddComponent<MeshRenderer>().material = FMaterial;
		if (FDepth < FMaxDepth)
			new GameObject ("Fractal Chaild").AddComponent<Fractal> ().Initialize(this);
	}

	private void Initialize(Fractal parParent)
	{
		FMesh = parParent.FMesh;
		FMaterial = parParent.FMaterial;
		FDepth = parParent.FDepth + 1;
		FChildScale = parParent.FChildScale;
		FMaxDepth = parParent.FMaxDepth;

		transform.parent = parParent.transform;
		transform.localScale = Vector3.one * FChildScale;
		transform.localPosition = Vector3.up * (0.5f + 0.5f * FChildScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
