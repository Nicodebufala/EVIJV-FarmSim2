using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour {

	public string nameRessource;
	public string nameObject;
	public string nameToolUsed = "null";
	public bool readyForHarvest;
	public float quantity = 0;
	public float quantitypertick = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		quantity += quantitypertick;
	}

	public virtual void harvest(GameObject player){
		if (nameToolUsed == "null" || player.GetComponent<ToolEquipped> ().checkIfToolEquipped (nameToolUsed)) {
			float tmp = quantity;
			quantity = 0f;
			player.GetComponent<InventoryManager> ().addElement (nameRessource, Mathf.CeilToInt (tmp));
		}

	}

}
