using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiAction : MonoBehaviour {

	public GameObject uiHolder;
	public GameObject mainMen;
	public GameObject menuButton;
	// Use this for initialization
	void Start () {
		uiHolder = GameObject.Find ("MenuUICanvas");
		mainMen = uiHolder.transform.Find ("Menu").gameObject;
		menuButton = uiHolder.transform.Find ("MenuButton").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closeMenu (){
		if (mainMen.activeSelf) {
			toggleMenu ();
		}
			
	}

	public void toggleMenu (){
		Debug.Log ("MENUUUUUU: " + mainMen.activeSelf);
		if (mainMen.activeSelf) {
			mainMen.SetActive (false);
			menuButton.SetActive (true);
		} else {
			mainMen.SetActive (true);
			menuButton.SetActive (false);
		}
	}	
}
