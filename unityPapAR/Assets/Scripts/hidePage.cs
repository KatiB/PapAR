using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidePage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// this object was clicked - do something
		// Destroy (this.gameObject);
		gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
		//gameObject.transform.Translate (1, 1, 1);
		gameObject.transform.SetPositionAndRotation (new Vector3(0, 0, 20), gameObject.transform.localRotation);

		if (gameObject.GetComponent<Renderer> ().enabled == false) {
			gameObject.transform.parent = null;
		}
	}
}
