using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void updateDisplay(){
		string tmp = "";
		ArrayList items = player.GetComponent<InventoryManager>().getRessources ();
		foreach(string s in items){
			tmp =tmp + s + "\n" ;
		}
		this.GetComponent<Text>().text = tmp;
	}
}
