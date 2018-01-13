using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolChoiceDisplay : MonoBehaviour {

	public GameObject toolBar;
	public GameObject selector;
	public GameObject player;
	public List<GameObject> tools;
	public List<string> nameTools;
	public Canvas canv;
	// Use this for initialization
	void Start () {
		nameTools = new List<string> ();
		toolBar = GameObject.FindGameObjectWithTag ("Inventorybar");
		selector = GameObject.FindGameObjectWithTag("Selector");
		player = GameObject.FindGameObjectWithTag("Player");
		for (int i = 0; i < tools.Count; i++){
			Instantiate (tools [i], selector.transform.position, Quaternion.identity);
		}
		GameObject[] toolsobjects = GameObject.FindGameObjectsWithTag ("Tool");
		for (int i = 0; i < toolsobjects.Length; i++){
			toolsobjects[i].transform.SetParent(toolBar.transform);
			toolsobjects[i].transform.position = selector.transform.position + new Vector3 (50 * i * canv.scaleFactor  , 0, 0);
			toolsobjects [i].transform.localScale = selector.transform.localScale * 0.9f;
			nameTools.Add (tools[i].name);
		}

	}
	
	// Update is called once per frame
	void Update () {
		int i = -1;
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			i = 0;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			i = 1;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			i = 2;
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			i = 3;
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			i = 4;
		}
		if(Input.GetKeyDown(KeyCode.Alpha6)){
			i = 5;		
		}
		if(Input.GetKeyDown(KeyCode.Alpha7)){
			i = 6;
		}
		if(Input.GetKeyDown(KeyCode.Alpha8)){
			i = 7;
		}
		if(Input.GetKeyDown(KeyCode.Alpha9)){
			i = 8;
		}
		if (i != -1) {
			selector.transform.localPosition = new Vector3(-200 + i*50,0,0);
			player.GetComponent<ToolEquipped> ().resetBool ();
			if (i < nameTools.Count) {
				player.GetComponent<ToolEquipped> ().checkEquip (nameTools [i]);
			}
		}


	}
}
