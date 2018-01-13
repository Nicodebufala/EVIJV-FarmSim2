using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingProductManager : MonoBehaviour {

	public List<GameObject> productsList;
	public bool[] availableSpaces;
	// Use this for initialization
	void Start () {
		productsList = new List<GameObject> ();
		availableSpaces = new bool[9];
		for (int i = 0; i < availableSpaces.Length; i++) {
			availableSpaces [i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addProduct(string name){
		GameObject prefabtmp = 	GameObject.FindObjectOfType<Terrain> ().GetComponentInChildren<ProductReferences> ().getPrefab (name);
		if (prefabtmp == null) {
			return;
		}
		int i = 0;
		while (i < availableSpaces.Length && !availableSpaces [i]) {
			i++;
		}
		if (i >= availableSpaces.Length) {
			return;
		}
		availableSpaces [i] = false;
		Vector3 pos = this.transform.position + new Vector3(i % 3,0,Mathf.FloorToInt(i / 3));
		GameObject tmp = (GameObject) GameObject.Instantiate (prefabtmp, pos, Quaternion.identity);
		tmp.transform.parent = this.transform;
		tmp.transform.localPosition = 2*5/3*(new Vector3(i % 3,0,Mathf.FloorToInt(i / 3))) + new Vector3(-4,0,-4);
		productsList.Add (tmp);
	}
}
