using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnableDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("started");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Debug.Log ("test2");
			this.enabled = false;
			Debug.Log ("test1");
			for (int i = 0; i < 10; i++) {
				Debug.Log (i);
			}
		}
	}

	void OnDisable(){
		Debug.Log ("I'm disabled");
		//this.enabled = true;
	}

	void OnEnable(){
		Debug.Log ("I'm enabled");
	}
}
