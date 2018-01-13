using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantChoiceMenuUI : MonoBehaviour {

	public GameObject soilTouched;
	public Dictionary<string,string> ressourceForButton;
	// Use this for initialization
	void Start () {
		ressourceForButton = new Dictionary<string,string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDisable(){
		
	}

	public void updateQuantities(){
		Image[] buttonsimg = this.GetComponentsInChildren<Image> ();
		Text[] buttonstext = new Text[buttonsimg.Length];
		for(int i = 0 ; i< buttonsimg.Length ;i++){
			if (buttonsimg[i].transform.parent.gameObject.name.Contains("-UI")) {
				buttonstext [i] = buttonsimg [i].gameObject.transform.parent.GetComponentInChildren<Text> ();
				string txt = buttonstext [i].text;
				//Debug.Log (gameObject.name);
				//Debug.Log (buttonsimg [i].gameObject.name);
				//Debug.Log (buttonstext[i].gameObject.name);
				//Debug.Log (txt);
				float qty = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ().getElementQuantity (txt);
				Debug.Log(buttonstext [i].gameObject.transform.GetComponentInChildren<Text> ().gameObject.name);
				buttonstext [i].gameObject.transform.GetComponentsInChildren<Text> ()[1].text = ("x " + Mathf.RoundToInt (qty)).ToString ();
				if (qty < 1f) {
					buttonsimg [i].gameObject.transform.GetComponent<Button> ().interactable = false;
				} else {
					buttonsimg [i].gameObject.transform.GetComponent<Button> ().interactable = true;
				}
			}


		}
	}

	public void onClickButton(string nameButton){
		if (nameButton == "quit") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<AnalyseAhead> ().changeLockState ();
			this.gameObject.SetActive(false);
		} else {
			string[] t = nameButton.Split (new string[] { "_" }, System.StringSplitOptions.None);
			GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager> ().removeElement (t[0],1);
			soilTouched.GetComponent<GrowingProductManager> ().addProduct (t[1]);
			updateQuantities ();
		}
	}
}
