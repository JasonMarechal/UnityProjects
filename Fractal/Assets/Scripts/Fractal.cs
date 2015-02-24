using UnityEngine;
using System.Collections;



public class Fractal : MonoBehaviour {
    
	public float FMaxRotationSpeed;
	private float FRotationSpeed;
    public int FMaxDepth;
    public Material FMaterial;
    public float FChildScale;
    private int FDepth;
	public Mesh[] FMeshs;

    private static Vector3[] FChildDirections = 
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] FChildOrientations =
    {
        Quaternion.identity,
        Quaternion.Euler (0f, 0f, -90f),
        Quaternion.Euler (0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

    private Material[,] FMaterials;
    private void InitializeMaterials () 
    {
        FMaterials = new Material[FMaxDepth + 1, 2];
        for (int i = 0; i <= FMaxDepth; i++) {
			float t = i / (FMaxDepth - 1f);
			t *= t;
            FMaterials[i, 0] = new Material(FMaterial);
            FMaterials[i, 0].color = Color.Lerp(Color.white, Color.yellow, t);
			FMaterials[i, 1] = new Material(FMaterial);
			FMaterials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
		}
		FMaterials[FMaxDepth, 0].color = Color.magenta;
		FMaterials[FMaxDepth, 1].color = Color.red;
    }

    // Use this for initialization
    void Start () {
		FRotationSpeed = Random.Range(-FMaxRotationSpeed, FMaxRotationSpeed);
        if (FMaterials == null) {
            InitializeMaterials();
        }
		gameObject.AddComponent<MeshFilter> ().mesh = FMeshs[Random.Range(0, FMeshs.Length)];
		gameObject.AddComponent<MeshRenderer> ().material = FMaterials [FDepth, Random.Range(0, 2)];
		if (FDepth < FMaxDepth)
            StartCoroutine (CreateChildren ());
    }

    private void Initialize(Fractal parParent, int parIndexChildren)
    {
		FMaxRotationSpeed = parParent.FMaxRotationSpeed;
        FMeshs = parParent.FMeshs;
        FMaterials = parParent.FMaterials;
        FDepth = parParent.FDepth + 1;
        FChildScale = parParent.FChildScale;
        FMaxDepth = parParent.FMaxDepth;

        transform.parent = parParent.transform;
        transform.localScale = Vector3.one * FChildScale;
        transform.localPosition = FChildDirections[parIndexChildren] * (0.5f + 0.5f * FChildScale);
        transform.localRotation = FChildOrientations[parIndexChildren];
    }

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < FChildDirections.Length; ++i) {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            new GameObject ("Fractal Chaild").AddComponent<Fractal> ().Initialize(this, i);
        }
    }
    
    // Update is called once per frame
    void Update () {
		transform.Rotate(0f, FRotationSpeed * Time.deltaTime, 0f);
	}
}
