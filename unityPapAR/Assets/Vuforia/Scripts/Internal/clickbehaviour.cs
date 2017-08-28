using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class clickbehaviour : MonoBehaviour
{
	public UnityEngine.UI.Text dispText2;

	void Update () {
		/**
		RaycastHit hit = new RaycastHit();
		for (int i = 0; i < Input.touchCount; ++i) {
			Debug.Log ("clickupdate.............");
			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.GetTouch(i).position);
				/**
				if (Physics.Raycast(ray, out hit)) {
					//hit.transform.gameObject.SendMessage("OnMouseDown");
					var clickTarget = hit.transform.name;
					var clickObject = hit.collider.name;
					dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
					dispText2.text = "Clicked " + clickTarget + ", " + clickObject;
				}
				**/
		/**
				handleClick (ray, hit); //http://answers.unity3d.com/questions/332085/how-do-you-make-an-object-respond-to-a-click-in-c.html
			}
		}

		Debug.Log ("clickupdate2.............");
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
			handleClick (ray, hit);
		}
	}

	public void handleClick (Ray ray, RaycastHit hit){
		if (Physics.Raycast(ray, out hit)) {
			//hit.transform.gameObject.SendMessage("OnMouseDown");
			var clickTarget = hit.collider.gameObject;
			var clickObject = hit.collider.name;

			//
			dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
			var texName = hit.collider.gameObject.GetComponentInChildren<Renderer> ().material.mainTexture.name;
			dispText2.text = "Clicked " + clickTarget.name + ", " + clickObject + ", " +texName;
			//

			if (clickTarget.transform.parent.name != "Camera") {
				var scriptHolderObject = GameObject.FindObjectOfType (typeof(floatingPage)) as floatingPage; //https://forum.unity3d.com/threads/calling-function-from-other-scripts-c.57072/
				Debug.Log ("Bis hier her!!!");
				//scriptHolderObject.takePage (texName);
			}
			addInfo (clickObject);
		}
	}

	public void addInfo(string clckPage){
		Debug.Log ("Display Infos...");

		GameObject clickedPage =  GameObject.Find (clckPage);
		GameObject lable = GameObject.CreatePrimitive(PrimitiveType.Plane);
		lable.transform.parent = clickedPage.transform;
		lable.transform.localEulerAngles = new Vector3 (90.0f, 0.0f, 180.0f);
		lable.transform.localPosition = new Vector3 (0.05f, 0f, 0f);
		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		dispText2.text = "Lable: " + lable.transform.parent.name;

	**/
	}
}