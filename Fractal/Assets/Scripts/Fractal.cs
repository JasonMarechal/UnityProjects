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
			StartCoroutine (CreateChildren ());
	}

	private void Initialize(Fractal parParent, Vector3 parDirection, Quaternion parOrientation)
	{
		FMesh = parParent.FMesh;
		FMaterial = parParent.FMaterial;
		FDepth = parParent.FDepth + 1;
		FChildScale = parParent.FChildScale;
		FMaxDepth = parParent.FMaxDepth;

		transform.parent = parParent.transform;
		transform.localScale = Vector3.one * FChildScale;
		transform.localPosition = parDirection * (0.5f + 0.5f * FChildScale);
		transform.localRotation = parOrientation;
	}

	private IEnumerator CreateChildren()
	{
		yield return new WaitForSeconds(0.5f);
		new GameObject ("Fractal Chaild").AddComponent<Fractal> ().Initialize(this, Vector3.up, Quaternion.identity);
		yield return new WaitForSeconds(0.5f);
		new GameObject ("Fractal Chaild").AddComponent<Fractal> ().Initialize(this, Vector3.right, Quaternion.Euler(0f, 0f, -90f));
		yield return new WaitForSeconds(0.5f);
		new GameObject ("Fractal Chaild").AddComponent<Fractal> ().Initialize(this, Vector3.left, Quaternion.Euler(0f, 0f, 90f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
