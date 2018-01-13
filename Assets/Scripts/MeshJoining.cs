using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshJoining : MonoBehaviour {

	public bool disableChild = true;
	// Use this for initialization
	void Start() {
		launchMJ ();
    }	

	public void launchMJ(){
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
		List<CombineInstance> tmp = new List<CombineInstance> ();
		int i = 1;
		while (i < meshFilters.Length) {
			if (meshFilters [i] != null) {
				CombineInstance t = new CombineInstance ();
				t.subMeshIndex = 0;
				t.mesh = meshFilters[i].sharedMesh;
				t.transform = Matrix4x4.TRS (meshFilters [i].transform.localPosition, meshFilters [i].transform.localRotation, meshFilters [i].transform.localScale);
				if (disableChild) {
					meshFilters [i].gameObject.SetActive (false);
				} else {
					meshFilters [i].gameObject.GetComponent<Collider> ().enabled = false;
				}
				tmp.Add (t);
			}
			i++;
		}
		Mesh m = new Mesh ();
		m.name = "test";
		CombineInstance[] combine = tmp.ToArray();
		m.CombineMeshes(combine,true);
		this.gameObject.GetComponent<MeshFilter>().mesh = m;
		if (this.gameObject.GetComponent<MeshCollider> ().enabled) {
			this.gameObject.GetComponent<MeshCollider> ().sharedMesh = m;
		}
		this.gameObject.GetComponent<MeshCollider> ().sharedMesh = m;
		if (!disableChild) {
			this.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
