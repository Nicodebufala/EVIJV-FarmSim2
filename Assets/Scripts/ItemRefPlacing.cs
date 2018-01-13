using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRefPlacing : MonoBehaviour {

	public GameObject prefab;
	public string nameProduct;
	public Dictionary<string,float> ressources;
	public Button button;
	public PlaceItemChoiceMenuUI ccUI;
	bool hovering;
	// Use this for initialization
	void Start () {
		Debug.Log ("test");
		this.GetComponent<Button> ().onClick.AddListener(delegate { ccUI.onClick (nameProduct);});
	}

	// Update is called once per frame
	void Update () {
	}

	public void changeHovering(bool val){
		hovering = val;
	}
		
}
