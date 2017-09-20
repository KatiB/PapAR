using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiAction : MonoBehaviour {

	//UI Elements
	public GameObject uiHolder;
	public GameObject mainMen;
	public GameObject menuButton; 
	public GameObject docDetail;
	public GameObject deskDocContainer;
	public GameObject docContainer;
	public GameObject searchHeader;
	public GameObject trackingLostIndicator;
	public GameObject pointer;
	public Text dispText2;
	public GameObject docHintText;
	public GameObject deskHintText;
	public Button docListMenu;
	public Button deskListMenu;
	public Button flBckBtn;
	public GameObject docMenu;
	public GameObject docSmalMenu;
	public GameObject docDetailMenu;

	public GameObject imgTargt;

	//Variables
	public bool trackingActive = false;

	// Use this for initialization
	void Start () {
		uiHolder = GameObject.Find ("MenuUICanvas");
		mainMen = uiHolder.transform.Find ("Menu").gameObject;
		menuButton = uiHolder.transform.Find ("MenuButton").gameObject;
		docDetail = uiHolder.transform.Find ("floatingPageHolderPanel").gameObject;
		deskDocContainer = uiHolder.transform.Find ("DeskList").gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
		searchHeader = uiHolder.transform.Find ("SearchDocHeaderPanel").gameObject;
		trackingLostIndicator = uiHolder.transform.Find ("WarningPanel").gameObject;
		//pointer = uiHolder.transform.Find ("PointerCube").gameObject;
		imgTargt = GameObject.Find ("ImageTarget");
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
		docListMenu.interactable = !visibilityState;
		deskListMenu.interactable = !visibilityState;
		trackingActive = !visibilityState;

	}

	public void setDeskHint (){
		if (deskDocContainer.transform.childCount == 0) {
			deskHintText.SetActive (true);
		} else {
			deskHintText.SetActive (false);
		}
	}

	public void setDocHint (){
		if (docContainer.transform.childCount == 0) {
			docHintText.SetActive (true);
		} else {
			docHintText.SetActive (false);
		}
	}

	public void showDocDetails(string docName){
		docDetail.transform.Find("FloatingPageHeader").gameObject.transform.Find ("FloatingPageName").gameObject.GetComponent<UnityEngine.UI.Text>().text = docName;
		docDetail.SetActive (true);
	}


	public void hideDocDetails(){
		if (docMenu != null && docSmalMenu != null) {
			docMenu.SetActive (false);
			docSmalMenu.SetActive (true);
		}
		if (docDetailMenu != null) {
			docDetailMenu.SetActive (false);
		}
		docDetail.SetActive (false);
	}


	//This is NOT used (?)
	public void fillListOfPlacedDocs (){
		Debug.Log ("LIST");
		foreach (Transform child in imgTargt.transform) {
			foreach (Transform childchild in child.transform){
				if (true) {
					string docNam = childchild.GetComponent<Renderer> ().material.mainTexture.name;
					CreateListElement (docNam);
				}
			}
		}
	}

	//Adding the newly palced Document to the Desk Overview List
	public void addPlacedDocToList(GameObject target){
		Debug.Log ("TARGET! " + target.name);
		var listElPre = Resources.Load ("DeskDocumentButton") as GameObject;
		var doc = GUIElement.Instantiate (listElPre, deskDocContainer.transform);
		var btn = doc.transform.GetChild (0);
		var tex = Resources.Load<Sprite>("Documents/" + target.GetComponent<Renderer> ().material.mainTexture.name);
		btn.GetComponent<Image> ().sprite = tex;
		btn.name = target.name;
		var docName = doc.transform.GetChild (1).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
		docName.text = tex.name;
		doc.name = tex.name;
		//doc.AddComponent<docPointer> ();
		//var dcPoint = btn.GetComponent<docPointer> ();
		//dcPoint.setTarget (target);

	}

	//remove Document from Desk overview List when it is picked up
	public void removeTakenDocFromList(string ListElName) {
		Debug.Log ("Remove " + ListElName + "Container: " + deskDocContainer.name);
		foreach (Transform child in deskDocContainer.transform) {
			Debug.Log ("DeskChild: " + child.name);
			if (child.transform.GetChild(0).name == ListElName){
				Debug.Log (child.transform.Find (ListElName).name);
				GameObject.Destroy (child.transform.Find (ListElName).transform.parent.gameObject);
			}
		}
		//uiHolder.transform.Find ("DeskList").gameObject.SetActive (true);
		//var listEl = deskDocContainer.transform.GetChild(0).transform.Find (ListElName).gameObject;
		//GameObject.Destroy (listEl.transform.parent.gameObject);
		//uiHolder.transform.Find ("DeskList").gameObject.SetActive (false);
	}

	//This is NOT used (?)
	public void CreateListElement (string docNam){
		Debug.Log ("CreateDesk " + docNam);
		var listElPre = Resources.Load ("DeskDocumentButton") as GameObject;
		Debug.Log ("TYPE" + listElPre.GetType ());
		var doc = GUIElement.Instantiate (listElPre, deskDocContainer.transform);
		var btn = doc.transform.GetChild (0);
		var tex = Resources.Load<Sprite>("Documents/" + docNam);
		btn.GetComponent<Image> ().sprite = tex;
		btn.name = tex.name;
		var docName = doc.transform.GetChild (1).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
		docName.text = tex.name;
	}


	public void pointToTarget (){
		//pointer.SetActive (true);
		if (pointer == null) {
			pointer = GameObject.Instantiate (Resources.Load ("PointerCube") as GameObject);
		}
		pointer.transform.parent = Camera.allCameras[0].transform;
		pointer.transform.localPosition = new Vector3 (0, 0.1f, 0.2f);
		pointer.AddComponent<docPointer> ();
		//var point = pointer.GetComponent<docPointer> ();
		//point.pointToDoc ();
	}

	public void setFlyBack (){
		Debug.Log ("Destiny! ");
		flBckBtn = GameObject.Find("flyBackButton").GetComponent<UnityEngine.UI.Button>();
		if (uiHolder.GetComponent<floatingPage> ().pickUpPage != null) {
			flBckBtn.interactable = true;
		} else {
			flBckBtn.interactable = false;
		}
	}

	public void cleanUp (){
		foreach (Transform child in imgTargt.transform) {
			GameObject.Destroy (child.gameObject);
		}
		foreach (Transform menuChild in deskDocContainer.transform) {
			if (menuChild.name != "DeskContent") {
				GameObject.Destroy (menuChild.gameObject);
			}
		}
	}
}
