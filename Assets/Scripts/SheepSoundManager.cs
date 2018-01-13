using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSoundManager : SoundManager {

	public AudioClip son;
	// Use this for initialization
	public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}

	public override void launchSound(){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.PlayOneShot (son);

	}
}
