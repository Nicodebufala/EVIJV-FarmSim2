using System.Collections.Generic; using System.Linq; using UnityEngine;

public class TreeGrowth : MonoBehaviour { 
	public float scaleMin = 0.1f; 
	public float scaleMax = 0.3f; 
	public int fruitMin = 5; 
	public int fruitMax = 15; 
	public float minHeightFruit;
	public GameObject  fruitPrefab;
	public List<GameObject> fruitList = new List<GameObject> ();
	public bool spawnFruit;
	float fruitscaleLimit;
	float treescaleLimit;

	void Start(){
		this.transform.rotation = new Quaternion(0, Random.Range(0, 350), 0, 0);
		if (fruitPrefab != null) {
			
			fruitscaleLimit = fruitPrefab.transform.localScale.x;
			Debug.Log (fruitscaleLimit);
		}
		treescaleLimit = this.transform.localScale.y;
		if (!spawnFruit) {
			List<MeshJoining> lst = new List<MeshJoining> ();
			this.GetComponentsInChildren<MeshJoining>(lst);
			if (!spawnFruit) {
				fruitscaleLimit = lst [0].gameObject.transform.localScale.x;
				Debug.Log (fruitscaleLimit);
				Debug.Log (lst[0].gameObject);

			}
			for (int i = 0; i < lst.Count; i++) {
				
				lst [i].gameObject.transform.localScale = lst [i].gameObject.transform.localScale * Random.Range(0.05f,0.1f);
			}
		}
		this.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f) * treescaleLimit;
		Debug.Log (fruitscaleLimit);

	}

	void Update(){
		if (this.transform.localScale.y > 0.3 && fruitList.Count == 0 & spawnFruit) {
			spawnInitial ();
		}
		if (this.transform.localScale.x < treescaleLimit) {
			this.transform.localScale = this.transform.localScale * (float)(1 + 0.1 * (Time.deltaTime));
		}
		updateFruit ();
	}
	void spawnInitial (){
	    try
	    {
			float fSize = this.transform.localScale.x;

	        //float fSize = Random.Range(scaleMin, scaleMax);
	        //this.transform.localScale = new Vector3(fSize, fSize, fSize);
	        //this.transform.rotation = new Quaternion(0, Random.Range(0, 350), 0, 0);

	        int iFruitMax = Random.Range(fruitMin, fruitMax);

	        if (iFruitMax > 0)
	        {

	            List<Vector3> vertices = GetComponent<MeshFilter>().sharedMesh.vertices.ToList();
	            float bottomValue = (vertices.Max(search => search.y))*minHeightFruit; //The /2 is to get an approximate top half value.

	            List<Vector3> verticesTOP = new List<Vector3>();
	            foreach (Vector3 vector3 in vertices)
	            {
	                if (vector3.y > bottomValue)
	                {
	                    verticesTOP.Add(vector3);
	                }
	            }

	            for (int bFruit = 0; bFruit < iFruitMax; bFruit++)
	            {
	                float ffSize = Random.Range(0.14f, 0.2f)*fSize;
	                GameObject fruit = GameObject.Instantiate(fruitPrefab);
					fruit.GetComponent<Rigidbody> ().useGravity = false;
					fruit.GetComponent<MeshCollider>().enabled = false;
	                fruit.transform.localScale = new Vector3(ffSize, ffSize, ffSize);
	                fruit.transform.parent = this.transform;
					fruit.transform.localPosition = verticesTOP[Random.Range(0, verticesTOP.Count - 1)] ;
					fruitList.Add(fruit);
	            }
	        }
	    }
	    catch
	    {
	        //Just in case...  Just eat the error.  nbd
	    }   
	}

	void updateFruit(){
		if (spawnFruit) {
			for (int i = 0; i < fruitList.Count; i++) {
				if (fruitList [i].transform.localScale.x < fruitscaleLimit) {
					fruitList [i].transform.localScale = fruitList [i].transform.localScale * (float)(1 + 0.1 * (Time.deltaTime));
				}else{
					if (Random.value < 0.001) {
						GameObject tmp = fruitList [i];
						tmp.GetComponent<Rigidbody> ().useGravity = true;
						tmp.GetComponent<MeshCollider> ().enabled = true;
						GameObject fruit = GameObject.Instantiate(fruitPrefab);
						fruit.GetComponent<Rigidbody> ().useGravity = false;
						fruit.GetComponent<MeshCollider>().enabled = false;
						float ffSize = Random.Range (0.05f, 0.1f);
						fruit.transform.localScale = new Vector3(ffSize, ffSize, ffSize);
						fruit.transform.parent = this.transform;
						fruit.transform.localPosition = tmp.transform.localPosition ;
						fruitList[i] = fruit;
					}

				}
			}
		} else {
			List<MeshJoining> lst = new List<MeshJoining> ();
			this.GetComponentsInChildren<MeshJoining>(lst);
			for (int i = 0; i < lst.Count; i++) {
				if (lst [i].gameObject.transform.localScale.x < fruitscaleLimit) {
					lst [i].gameObject.transform.localScale = lst [i].gameObject.transform.localScale * (float)(1 + 0.1 * (Time.deltaTime));
				}else{
					if (Random.value < 0.001 && lst[i].gameObject.GetComponent<Rigidbody>().isKinematic) {
						GameObject tmp = lst [i].gameObject;
						GameObject fruit = GameObject.Instantiate (fruitPrefab);
						fruit.transform.parent = tmp.transform.parent;
						tmp.GetComponent<Rigidbody> ().useGravity = true;
						tmp.GetComponent<MeshCollider> ().enabled = true;
						tmp.GetComponent<Rigidbody> ().isKinematic = false;
						fruit.transform.localPosition = tmp.transform.localPosition;
						fruit.transform.localRotation = tmp.transform.localRotation;
						fruit.GetComponent<Rigidbody> ().useGravity = false;
						fruit.GetComponent<MeshCollider> ().enabled = false;
						fruit.GetComponent<Rigidbody> ().isKinematic = true;
						float ffSize = Random.Range (0.05f, 0.1f);
						fruit.transform.localScale = tmp.transform.localScale*ffSize;
						fruit.transform.parent = this.transform;
						fruit.transform.localPosition = tmp.transform.localPosition;
						MeshFilter[] children = fruit.GetComponentsInChildren<MeshFilter> ();
						for (int j = 0; j < children.Length; j++) {
							children [j].gameObject.SetActive (true);
						}
						tmp.transform.parent = null;
						//fruit.GetComponent<MeshJoining> ().launchMJ ();
					}
				}
			}
		}

	}

}