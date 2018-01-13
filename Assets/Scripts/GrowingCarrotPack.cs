using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingCarrotPack : MonoBehaviour {

	public float limit;
	public List<GameObject> fruitList = new List<GameObject> ();
	public int fruitMin; 
	public int fruitMax; 
	public GameObject  fruitPrefab;

	// Use this for initialization
	void Start () {
		float x = 0;
		float z = 0;
		float step = Mathf.Sqrt ((float)fruitMax);
		for (int bFruit = 0; bFruit < fruitMax; bFruit++)
		{
			float ffSize = Random.Range(0.14f, 0.2f);
			GameObject fruit = GameObject.Instantiate(fruitPrefab);
			fruit.GetComponent<Rigidbody> ().useGravity = false;
			fruit.transform.localScale = new Vector3(ffSize, ffSize, ffSize);
			fruit.transform.parent = this.transform;
			fruit.transform.localPosition =  new Vector3( x ,-0.4f, z ) * ( 1.1f*limit ) ; 
			fruit.transform.Rotate(new Vector3 (90, 0, 0));
			fruitList.Add(fruit);
			fruit.GetComponent<Rigidbody> ().isKinematic = true;
			x = (x + 1) % step;
			if (x == 0) {
				z = z + 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateFruit();
	}

	void updateFruit(){
		for (int i = 0; i < fruitList.Count; i++) {
			if (fruitList[i].transform.localScale.x < limit) {
				fruitList[i].transform.localScale = fruitList[i].transform.localScale * (float)(1 + 0.1 * (Time.deltaTime));
			}
		}
	}
}
