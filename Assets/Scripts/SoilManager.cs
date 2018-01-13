using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour {
	public List<GameObject> soilList;
	public GameObject soilPrefab;
	// Use this for initialization
	void Start () {
		soilList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createSoil (Vector3 point){
		float x = Mathf.Round(point.x/5)*5;
		float y = point.y + 0.03f;
		float z = Mathf.Round(point.z/5)*5;
		for (int i = 0; i < soilList.Count; i++) {
			if (soilList [i].transform.position.x == x && soilList [i].transform.position.z == z) {
				return;
			}
		}
		GameObject tmp = (GameObject) GameObject.Instantiate (soilPrefab, new Vector3 (x, y, z), Quaternion.identity);
		soilList.Add (tmp);


	}
}
