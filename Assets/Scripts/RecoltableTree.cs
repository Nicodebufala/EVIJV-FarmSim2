using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoltableTree : Recoltable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void harvest(GameObject player){
		if (player.GetComponent<ToolEquipped> ().axe) {
			float tmp = quantity;
			quantity = 100f; // pour le respawn
			player.GetComponent<InventoryManager>().addElement(nameRessource,Mathf.CeilToInt(tmp));
			GameObject.FindObjectOfType<Terrain> ().GetComponentInChildren<TreeGenerator> ().addArbreToRespawn (this.transform.position, Time.time + 5f, this.gameObject);
		}
	}
}
