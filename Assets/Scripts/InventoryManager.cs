using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public Dictionary<string,float> inventory;
	public Dictionary<string,int> craftedItems;
	public GameObject gui;

	// Use this for initialization
	void Start () {
		craftedItems = new Dictionary<string,int> ();
		inventory = new Dictionary<string,float> ();
		inventory.Add ("Banana seed", 5f);
		inventory.Add ("Wood", 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addElement(string name,float quantity, bool craftedItem = false){
		if (craftedItem) {
			if (craftedItems.ContainsKey (name)) {
				int val = 0;
				craftedItems.TryGetValue (name, out val);
				craftedItems.Remove (name);
				craftedItems.Add (name, ((int)quantity) + val);
			} else {
				craftedItems.Add (name, (int)quantity);
			}

		} else {
			if (inventory.ContainsKey (name)) {
				float val = 0f;
				inventory.TryGetValue (name, out val);
				inventory.Remove (name);
				inventory.Add (name, quantity + val);
			} else {
				inventory.Add (name, quantity);
			}
			gui.GetComponent<InventoryDisplay> ().updateDisplay ();
		}
	}

	public bool removeElement(string name,float quantity){
		float stock = 0f;
		if (inventory.ContainsKey (name)) {
			inventory.TryGetValue (name, out stock);
			if (stock >= quantity) {
				stock -= quantity;
				inventory.Remove (name);
				if (stock > 0) {
					inventory.Add (name, stock);
				}
				gui.GetComponent<InventoryDisplay>().updateDisplay ();
				return true;
			} else {
				return false;
			}
		} else {
			if (craftedItems.ContainsKey (name)) {
				int val = 0;
				craftedItems.TryGetValue (name, out val);
				if (val >= (int)quantity) {
					val -= (int)quantity;
					craftedItems.Remove (name);
					if (val > 0) {
						craftedItems.Add (name, val);
					}
					gui.GetComponent<InventoryDisplay> ().updateDisplay ();
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}
		}

	}

	public float getElementQuantity(string name){
		float stock = 0f;
		if (inventory.ContainsKey (name)) {
			inventory.TryGetValue (name, out stock);
			return stock;
		} else {
			int val = 0;
			if (craftedItems.ContainsKey (name)) {
				craftedItems.TryGetValue (name, out val);

			}
			return (float) val;
		}
	}

	public ArrayList getRessources(){
		ArrayList arr = new ArrayList ();
		foreach (KeyValuePair<string,float> kvp in inventory)
		{
			//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
			arr.Add( string.Format("{0} : {1}", kvp.Key, kvp.Value.ToString()));
		}
		return arr;
	}

	public bool checkIfRecipePossible(Dictionary<string,float> d){
		foreach (KeyValuePair<string,float> kvp in d)
		{
			float f = getElementQuantity (kvp.Key);
			if (f < kvp.Value) {
				return false;
			}
		}
		return true;
	}

	public bool removeElements(Dictionary<string,float> d){
		foreach (KeyValuePair<string,float> kvp in d)
		{
			float f = getElementQuantity (kvp.Key);
			if (f < kvp.Value) {
				return false;
			}
		}
		foreach (KeyValuePair<string,float> kvp in d)
		{
			removeElement (kvp.Key,kvp.Value);
		}
		return true;
	}

	public Dictionary<string,int> getCraftedItems(){
		return craftedItems;
	}
}
