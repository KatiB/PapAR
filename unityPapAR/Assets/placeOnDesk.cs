using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeOnDesk : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void placeOnPlane() {
		Debug.Log ("Update Desk?");
		Plane targetPlane = new Plane (transform.up, transform.position);

		foreach (Touch touch in Input.touches) {
			Ray ray = Camera.allCameras [0].ScreenPointToRay (touch.position);
			float dist = 0.0f;
			targetPlane.Raycast (ray, out dist);
			Vector3 planePoint = ray.GetPoint (dist);

			//Instantiate (GameObject.CreatePrimitive (PrimitiveType.Cube), planePoint, Quaternion.identity);

			GameObject page = GameObject.CreatePrimitive(PrimitiveType.Plane);
			page.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
			page.transform.localPosition = planePoint;

			Texture demotex = Resources.Load ("DemoDocTexture") as Texture;
			page.GetComponent<Renderer> ().material.mainTexture = demotex;

			page.gameObject.SetActive(true);

		}
	}
}
