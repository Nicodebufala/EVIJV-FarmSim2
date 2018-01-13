using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ProductReferences : MonoBehaviour {

	public class CraftItem {
		public string name;
		public GameObject prefab;
		public Dictionary<string,float> ressourcesList;
		public Sprite photo;

		public CraftItem(string n, GameObject go, Dictionary<string,float> lst, Texture2D p){
			name = n;
			prefab = go;
			ressourcesList = lst;
			photo = Sprite.Create(p,new Rect(0,0,p.width,p.height),new Vector2(0.5f,0.5f));
		}
	}

	public List<GameObject> productList = new List<GameObject> ();
	public Texture2D texture;
	public TextAsset craftProductDatabase;
	List<CraftItem> craftItemList;
	// Use this for initialization
	void Start () {
		//texture.Resize (20, 40);
		//Cursor.SetCursor (texture, new Vector2 (0, 0), CursorMode.ForceSoftware);
		craftItemList = new List<CraftItem>();
		readCraftDB();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public GameObject getPrefab(string name){
		for (int i = 0; i < productList.Count; i++) {
			if (productList [i].name == name) {
				return productList [i];
			}
		}
		return null;

	}

	void readCraftDB(){
		string[] buffer = craftProductDatabase.text.Split ('\n');
		int i = 0;
		while(i < buffer.Length){
			if (buffer [i].Length > 0) {
				buffer [i] = buffer [i].Remove (buffer [i].Length - 1);
			}
			i++;
		}
		i = 0;
		while(i<buffer.Length){
			if (buffer [i++] == "___") {
				string nameCraft = buffer [i++];
				string namePref = buffer [i++];
				Dictionary<string,float> t = new Dictionary<string,float> ();
				while (i < buffer.Length && buffer[i].Length > 0 && buffer [i] [0] == '-') {
					string[] tmp = buffer [i++].Split (' ');
					int qty = 0;
					int.TryParse (tmp [1], out qty);
					if (qty > 0) {
						t.Add (tmp [2], (float)qty);
					}
				}
				//Debug.Log (namePref);
				//Debug.Log ((GameObject)Resources.Load (namePref));
				//Debug.Log (Resources.Load (namePref + "photo"));
				craftItemList.Add (new CraftItem (nameCraft, (GameObject)Resources.Load (namePref), t, (Texture2D)Resources.Load (namePref + "photo")));


			}
		}
	}
	public List<CraftItem> getCraftItemList(){
		return craftItemList;
	}
}
