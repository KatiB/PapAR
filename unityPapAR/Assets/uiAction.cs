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
	public GameObject trackingLostIndicator;
	public GameObject pointer;
	public UnityEngine.UI.Text dispText2;

	public GameObject imgTargt;

	// Use this for initialization
	void Start () {
		uiHolder = GameObject.Find ("MenuUICanvas");
		mainMen = uiHolder.transform.Find ("Menu").gameObject;
		menuButton = uiHolder.transform.Find ("MenuButton").gameObject;
		docDetail = uiHolder.transform.Find ("floatingPageHolderPanel").gameObject;
		//deskDocContainer = uiHolder.transform.Find ("DeskContent").gameObject;
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

	}

	public void showDocDetails(string docName){
		docDetail.transform.Find("FloatingPageHeader").gameObject.transform.Find ("FloatingPageName").gameObject.GetComponent<UnityEngine.UI.Text>().text = docName;
		docDetail.SetActive (true);
	}

	public void hideDocDetails(){
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
}
