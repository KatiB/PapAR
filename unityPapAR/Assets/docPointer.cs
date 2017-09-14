using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class docPointer : MonoBehaviour {


	public GameObject pointer;

	//public findTarget trgtFinder;


	public GameObject targetDoc;
	// Use this for initialization
	void Start () {
		pointer = GameObject.Find ("PointerSphere(Clone)");
		//trgtFinder = Resources.Load<findTarget> ("");
		}

	
	// Update is called once per frame
	void Update () {
		if (pointer == null) {
			pointer = GameObject.Find ("PointerSphere(Clone)");
		}

		if (targetDoc != null) {
			pointer.transform.LookAt (targetDoc.transform.position);
			/**
			if (targetDoc.transform.parent.transform.GetChild (1).GetComponent<Renderer> ().isVisible) {
				Debug.Log ("ICU!");
				trgtFinder.destroyPointer ();

			} else {
				//var dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
				//dispText2.text = "Set Active!!!!!!!!!!!!!!!!";
				Debug.Log ("PointerName: ");// + Camera.allCameras [0].transform.Find (pointer.name).gameObject.name);
				//Camera.allCameras [0].transform.Find (pointer.name).gameObject.SetActive (true);
				trgtFinder.createPointer();
			}
			**/
		}

	}

	public void pointToDoc (string targtNam){
		//GameObject qb = GameObject.Find ("Cube");
		//pointer = GameObject.Find ("PointerCube(Clone)");
		//GameObject cam = GameObject.Find ("Camera");
		//Debug.Log ("Pointer: " + qb.transform.position + ", " + pointer.transform.position);
		//Vector3 targetRelToCam = qb.transform.position - cam.transform.position;
		//Debug.Log ("Pointercalc: " + targetRelToCam);
		//float angle = Mathf.Atan2 (targetRelToCam.x, targetRelToCam.y);
		//Debug.Log ("PointercalcAngle: " + angle);
		//Debug.Log ("Look! at" + target.name);

		//if (pointer == null) {
		//	pointer = GameObject.Instantiate (Resources.Load ("PointerCube") as GameObject);
		//}
		//pointer.transform.parent = Camera.allCameras[0].transform;
		//pointer.transform.localPosition = new Vector3 (0, 0.1f, 0.2f);
		//pointer.AddComponent<docPointer> ();

		//pointer.transform.LookAt (target.transform.position);
		targetDoc = GameObject.Find (targtNam);
		//pointer.transform.LookAt (target.transform.position);
		Debug.Log ("DOCTARGET: " + targetDoc.name);
		GameObject highlightFrame = Resources.Load ("highlightPlane") as GameObject;
		GameObject.Instantiate (highlightFrame, targetDoc.transform.parent.transform);
		Debug.Log ("Still here!");


	}

	public void setTarget(GameObject tgt){
		//target = tgt;
		Debug.Log ("setTarget");
	}
}
