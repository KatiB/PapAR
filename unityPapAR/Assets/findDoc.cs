using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findDoc : MonoBehaviour {

	public GameObject menU;
	public uiAction menuControl;

	public InputField DocSearchInputField;
	// Use this for initialization
	void Start () {
		menU = GameObject.Find ("MenuUICanvas");
		menuControl = menU.GetComponent<uiAction> ();
		DocSearchInputField = gameObject.GetComponent<InputField> ();
		menuControl.fillListOfPlacedDocs ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void docList () {
		
		Debug.Log ("SEARCH! ");
		Debug.Log ("Term: " + DocSearchInputField.text);
	}
}
