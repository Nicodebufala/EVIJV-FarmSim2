using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRefCrafting : MonoBehaviour {

	public GameObject prefab;
	public string nameProduct;
	public Dictionary<string,float> ressources;
	public Button button;
	public Text recetteGui;
	public CraftChoiceMenuUI ccUI;
	public string recetteItem;
	bool hovering;
	// Use this for initialization
	void Start () {
		this.GetComponent<Button> ().onClick.AddListener(delegate { ccUI.onClick (nameProduct);});
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void changeHovering(bool val){
		hovering = val;

		if (val) {
			recetteGui.text = recetteItem;
		} else {
			recetteGui.text = "";
		}
	}

	void showMessage(){
		recetteGui.text = recetteItem;
		//Debug.Log("pos souris : " +Input.mousePosition );

	}
}
