using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RessourceManager : MonoBehaviour {

	// Use this for initialization
	public abstract void Start () ;
	
	// Update is called once per frame
	public abstract void Update () ; 

	public abstract void getRessource (GameObject player);
}
