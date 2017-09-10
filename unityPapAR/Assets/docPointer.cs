using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class docPointer : MonoBehaviour {


	public GameObject pointer;


	public GameObject targetDoc;
	// Use this for initialization
	void Start () {
		pointer = GameObject.Find ("PointerCube(Clone)");
		}
	
	// Update is called once per frame
	void Update () {
		if (pointer == null) {
			pointer = GameObject.Find ("PointerCube(Clone)");
		}
		pointer.transform.LookAt (targetDoc.transform.position);
		
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


	}

	public void setTarget(GameObject tgt){
		//target = tgt;
		Debug.Log ("setTarget");
	}
}
