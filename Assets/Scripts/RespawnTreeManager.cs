 using UnityEngine;
 using System.Collections;
 using System;
 using System.Collections.Generic;
 
 // Attach this to a Singleton-like GameObject of which there is only and will ever only be one,
 // ala classic GameManager object.
 
 public class RespawnTreeManager : MonoBehaviour {

     // Tree Harvest script access
	public List<float> managedTreesRespawn = new List<float>();
	public List<Transform> managedTreesTransform = new List<Transform>();
	public List<TreeInstance> managedTrees= new List<TreeInstance>();
	public Terrain terrain;
 
     void Start() {
         InvokeRepeating ("RespawnTree", 5, 5);
     }
 
 
     private void RespawnTree() {
 
         if (managedTreesRespawn.Count == 0)
             return;
 
         // Removing the demo cube and allowing tree to be used again
         for (int cnt=0; cnt < managedTreesRespawn.Count; cnt++) {
			if(managedTreesRespawn[cnt] < Time.time) {
				Destroy(managedTreesTransform[cnt].gameObject);
                managedTreesRespawn.RemoveAt(cnt);
				managedTreesTransform.RemoveAt(cnt);
				terrain.AddTreeInstance(managedTrees[cnt]);
				managedTrees.RemoveAt (cnt);
				float[,] heights = terrain.terrainData.GetHeights(0, 0, 0, 0);
				terrain.terrainData.SetHeights(0, 0, heights);
				 
                return;
             }
 
         }
     }
 
 
	public void addTree(float _respawnTime, Transform _marker,TreeInstance ti) {
 		
		managedTreesRespawn.Add (_respawnTime);
		managedTreesTransform.Add (_marker);
		managedTrees.Add (ti);
     }
 }