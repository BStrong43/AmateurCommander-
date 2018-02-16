using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	// Use this for initialization
	public int herders = 0,
			   poachers = 0,
			   lions = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateUI ();
	}

	void OnTriggerExit2D(Collider2D col){
		string tag = col.tag;

		switch (tag) {
		case "Lion":
			lions++;
			break;
		case "Herder":
			herders++;
			break;
		case "Poacher":
			poachers++;
			break;
		}

		Destroy (col.gameObject);
	}

	void updateUI(){

	}
}
