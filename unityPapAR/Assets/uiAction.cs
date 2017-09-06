using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiAction : MonoBehaviour {

	//UI Elements
	public GameObject uiHolder;
	public GameObject mainMen;
	public GameObject menuButton;
	public GameObject docDetail;
	public GameObject trackingLostIndicator;
	public UnityEngine.UI.Text dispText2;

	// Use this for initialization
	void Start () {
		uiHolder = GameObject.Find ("MenuUICanvas");
		mainMen = uiHolder.transform.Find ("Menu").gameObject;
		menuButton = uiHolder.transform.Find ("MenuButton").gameObject;
		docDetail = uiHolder.transform.Find ("floatingPageHolderPanel").gameObject;
		trackingLostIndicator = uiHolder.transform.Find ("WarningPanel").gameObject;
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

	//displays a warning, if tracking is lost
	public void toggleTrackingWarning (bool visibilityState){
		if (dispText2 == null) {
			dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		}
		if (visibilityState) {
			dispText2.text = "Tracking is lost!";
		} else {
			dispText2.text = "There is the Tracking!";
		}
		/**
		if (trackingLostIndicator == null) {
			trackingLostIndicator = GameObject.Find ("WarningPanel");
		}**/
		trackingLostIndicator.SetActive (visibilityState);

	}

	public void showDocDetails(string docName){
		docDetail.transform.Find("FloatingPageHeader").gameObject.transform.Find ("FloatingPageName").gameObject.GetComponent<UnityEngine.UI.Text>().text = docName;
		docDetail.SetActive (true);
	}

	public void hideDocDetails(){
		docDetail.SetActive (false);
	}
}
