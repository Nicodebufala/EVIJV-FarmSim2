using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTreeManager : MonoBehaviour {

	public float distanceRecolte;

	public bool rotationCharacter = true;

	private Transform transfo;

	public Terrain mainTerrain;

	private RaycastHit hit;

	public GameObject deadTree;

	private RespawnTreeManager treeMgr;

	public float respawnTime;

	// Use this for initialization
	void Start () {
		transfo= transform;
		treeMgr = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<RespawnTreeManager> ();

	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Debug.Log (" E appuyé ! ");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray,out hit,5f)){
				Debug.Log (hit.collider.gameObject.name + "touché ! ");
				if(hit.collider.gameObject.tag != "Tree"){
					return;
				}


				GameObject marker = GameObject.CreatePrimitive (PrimitiveType.Cube);
				marker.transform.position = hit.collider.gameObject.transform.position;
				Destroy (hit.collider.gameObject);
				marker.SetActive (false);
				GameObject tronc = Instantiate (deadTree, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
				Destroy(tronc,4);

			}
		}
	}*/
	
	/*void recolte(){	
		Debug.Log (" Recolte ! ");
		int numArbre = -1;
		float distance = distanceRecolte;
		int treeMaxIndex = mainTerrain.terrainData.treeInstances.Length;
		Vector3 posArbre = new Vector3 (0, 0, 0);
		for (int i = 0; i < treeMaxIndex; i++) {
			Vector3 tmp = Vector3.Scale (mainTerrain.terrainData.treeInstances [i].position, mainTerrain.terrainData.size) + mainTerrain.transform.position;
			float tmpdist = Vector3.Distance (tmp, hit.point);
			if (tmpdist < distance) {
				numArbre = i;
				distance = tmpdist;
				posArbre = tmp;
			}
		}
		if (numArbre != -1) {

			GameObject marker = GameObject.CreatePrimitive (PrimitiveType.Cube);
			marker.transform.position = posArbre;
			marker.SetActive (false);
			GameObject tronc = Instantiate (deadTree, posArbre, Quaternion.identity) as GameObject;
			Destroy(tronc,4);
			treeMgr.addTree (Time.time + respawnTime, marker.transform,mainTerrain.terrainData.treeInstances[numArbre]);
			List<TreeInstance> newTrees = new List<TreeInstance> (mainTerrain.terrainData.treeInstances);
			newTrees.RemoveAt (numArbre);
			mainTerrain.terrainData.treeInstances = newTrees.ToArray ();
			float[,] heights = mainTerrain.terrainData.GetHeights(0, 0, 0, 0);
			mainTerrain.terrainData.SetHeights(0, 0, heights);
			if (rotationCharacter) {
				Vector3 tmp = new Vector3 (hit.point.x, transfo.position.y, hit.point.z); 
				transfo.LookAt (tmp);
			}
			this.gameObject.GetComponent<InventoryManager> ().addElement ("Wood", 100);


		}


	}*/
}