using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolManager : RessourceManager {

	public float woolQuantity = 0f;
	// Use this for initialization
	public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		woolQuantity += 1;
	}

	public override void getRessource(GameObject player){
		Debug.Log ("Wool enlevé" + player.name);
		player.GetComponent<InventoryManager>().addElement("Wool",woolQuantity);
		woolQuantity = 0;
	}
}
