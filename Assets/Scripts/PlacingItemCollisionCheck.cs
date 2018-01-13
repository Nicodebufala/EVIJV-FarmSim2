using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingItemCollisionCheck : MonoBehaviour {

	public List<Collider> inZonelst;
	// Use this for initialization
	void Start () {
		inZonelst = new List<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		if(!inZonelst.Contains(other)){
			inZonelst.Add (other);
		}
	}

	public void OnTriggerExit(Collider other){
		if(inZonelst.Contains(other)){
			inZonelst.Remove (other);
		}
	}
}
