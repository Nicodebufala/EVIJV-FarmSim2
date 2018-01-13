using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceItemChoiceMenuUI : MonoBehaviour {

	List<ProductReferences.CraftItem> lstCraftItems;
	public Image content;
	public GameObject prefabButton;
	public Text recetteTexteGui;
	public List<GameObject> goButton;
	// Use this for initialization
	void Start () {
		lstCraftItems = new List<ProductReferences.CraftItem> ();
		goButton = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {

		if (lstCraftItems == null || lstCraftItems.Count == 0) {
			lstCraftItems = GameObject.FindGameObjectWithTag("Terrain").GetComponentInChildren<ProductReferences> ().getCraftItemList ();
			initUi ();
		}
	}

	void initUi(){
		for (int i = 0; i < lstCraftItems.Count; i++) {
			GameObject g = Instantiate (prefabButton);
			g.gameObject.name = lstCraftItems [i].name + "UI";
			Button b = g.GetComponent<Button> ();
			b.gameObject.GetComponent<Image>().sprite = lstCraftItems[i].photo;
			//b.GetComponentInChildren<Text> ().text = lstCraftItems [i].name;
			b.GetComponent<ItemRefPlacing> ().prefab = lstCraftItems [i].prefab;
			b.GetComponent<ItemRefPlacing> ().ressources = lstCraftItems [i].ressourcesList;
			b.GetComponent<ItemRefPlacing> ().nameProduct = lstCraftItems [i].name;
			b.GetComponent<ItemRefPlacing> ().ccUI = this;

			b.gameObject.transform.SetParent(content.transform,false);
			//Image hoverMessage = b.gameObject.GetComponentsInChildren<Image> (true) [1];
			//Text recipe = hoverMessage.GetComponentInChildren<Text> ();
			string tmp = "";
			foreach (KeyValuePair<string,float> kvp in lstCraftItems[i].ressourcesList)
			{
				//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
				tmp +=( string.Format("{0} : {1}", kvp.Key, kvp.Value.ToString()) + "\n");
			}
			b.interactable = ( GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ().getElementQuantity(lstCraftItems[i].prefab.GetComponent<ProductRef>().nameProduct) > 0 );
			goButton.Add (g);
		}


	}

	public void checkAvailabilities(){
		for (int i = 0; i < goButton.Count; i++) {
			goButton[i].GetComponent<Button>().interactable = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ().getElementQuantity(goButton[i].GetComponent<ItemRefPlacing>().prefab.GetComponent<ProductRef>().nameProduct) > 0;
		}
	}

	public void onClick(string choice){
		GameObject p = GameObject.FindGameObjectWithTag ("Player");
		if (choice == "quit") {
			p.GetComponent<AnalyseAhead> ().changeLockState ();
			this.gameObject.SetActive(false);
		} else {
			int i = 0;
			for (i = 0; i < lstCraftItems.Count; i++) {
				if (lstCraftItems [i].name == choice) {
					//Placing and removing from inventory
					p.GetComponent<AnalyseAhead> ().itemToPlace = lstCraftItems [i].prefab;
					checkAvailabilities ();
					p.GetComponent<AnalyseAhead> ().inPlacementMode = true;
					p.GetComponent<AnalyseAhead> ().changeLockState ();
					this.gameObject.SetActive(false);
					return ;
				}
			}
			Debug.Log ("Weird button choice : " + choice);
		}
	}
}
