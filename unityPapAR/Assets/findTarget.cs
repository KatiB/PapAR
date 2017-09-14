using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findTarget : MonoBehaviour {


	public GameObject menU;

	// Use this for initialization
	void Start () {
		menU = GameObject.Find ("MenuUICanvas");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createPointer(){
		destroyPointer ();
		var pointer = GameObject.Instantiate (Resources.Load ("PointerCube") as GameObject);
		pointer.transform.parent = Camera.allCameras[0].transform;
		pointer.transform.localPosition = new Vector3 (0, 0.1f, 0.2f);
		pointer.AddComponent<docPointer> ();
		var point = pointer.GetComponent<docPointer> ();
		point.pointToDoc (gameObject.name);
	}

	public void setSearchHeader(GameObject listDoc){
		var searchHeader = menU.transform.Find ("SearchDocHeaderPanel").gameObject;
		var deskDocList = menU.transform.Find ("DeskList").gameObject;
		var menuBtn = menU.transform.Find ("MenuButton").gameObject;
		//var img = searchHeader.GetComponent<> ().material.mainTexture;
		searchHeader.SetActive(true);
		deskDocList.SetActive (false);
		menuBtn.SetActive (true);
		Sprite tex = Resources.Load<Sprite> ("Documents/" +listDoc.name);
		GameObject imageHolder = searchHeader.transform.GetChild (0).gameObject;
		imageHolder.GetComponent<Image> ().sprite = tex;
		searchHeader.transform.GetChild (1).GetComponent<UnityEngine.UI.Text> ().text = tex.name;
	}

	public void destroyPointer (){
		var currentPointer = GameObject.Find ("PointerCube(Clone)");
		if (currentPointer != null) {
			GameObject.Destroy (currentPointer);
		}
	}
}
