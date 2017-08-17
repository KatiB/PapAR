using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dispButtonType : MonoBehaviour {

	public UnityEngine.UI.Text dispText2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/**
		if (dispText2 == null) {
			dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		}
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				dispText2.text = "KeyCode down: " + kcode;
		}

		if (Input.GetKey(KeyCode.F8) || Input.GetKey(KeyCode.F9) || Input.GetKey(KeyCode.F10) || Input.GetKey(KeyCode.Space)) {
			dispText2.text = "KeyCode down: ";
		}
		**/
	}
}
