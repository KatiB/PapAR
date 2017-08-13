﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingPage : MonoBehaviour {


	public UnityEngine.UI.Text dispText2;
	public string currentTextureName = "DemoDocTexture";
	//public Texture demotex = Resources.Load ("DemoDocTexture") as Texture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takePage (string texName) {
		currentTextureName = texName;
		//Texture demotex = Resources.Load (currentTextureName) as Texture;

		//dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		//GameObject floatingImgBtn = gameObject.transform.Find ("activePageButton").gameObject;
		//GameObject floatingImg = floatingImgBtn.transform.Find ("ActiveImagePanel").gameObject;

		//dispText2.text = gameObject.name + "; " + texName + "; " + floatingImg.name;
		//gameObject.GetComponent<Renderer> ().material.mainTexture = demotex;
		//gameObject.GetComponent<Renderer> ().material.mainTexture = demotex;
		//floatingImg.gameObject.SetActive(true);
		GameObject floatingImagePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);

		Texture demotex = Resources.Load (currentTextureName) as Texture;


		floatingImagePlane.GetComponent<Renderer> ().material.mainTexture = demotex;
		floatingImagePlane.name = texName;
		floatingImagePlane.transform.localScale = new Vector3(0.008f, 0.008f, 0.005f);
		floatingImagePlane.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);
		floatingImagePlane.transform.parent = Camera.allCameras[0].transform;

		floatingImagePlane.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		floatingImagePlane.transform.localEulerAngles = new Vector3 (90f, 0f, 180f);
		//floatingImagePlane.transform.SetPositionAndRotation (floatingImagePlane.transform.parent.position, floatingImagePlane.transform.parent.localRotation);
		floatingImagePlane.transform.Translate (0.0f, -0.2f, 0.0f);
		//floatingImagePlane.transform.localScale = new Vector3(demotex.width, 0.008f, demotex.height);
		//floatingImagePlane.transform.localScale = new Vector3(0.008f, 0.008f, 0.005f);

		//floatingImagePlane.transform.localScale = new Vector3 (Screen.width, 0.01f, Screen.height);

		//

		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		dispText2.text = Screen.width + "GNAAA!!" + demotex.name;

		//
		floatingImagePlane.gameObject.SetActive(true);

	}

	public void createSelectedPage () {
		Debug.Log ("Adding model...");

		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject imagePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);

		// Adjust scale and position 
		// (use localScale and localPosition to make it relative to the parent)
		cube.transform.localScale = new Vector3(0.1f, 0.15f, 0.015f);
		cube.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);
		cube.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		cube.transform.Translate (0.0f, 0.0f, 0.21f);


		Texture demotex = Resources.Load (currentTextureName) as Texture;
		imagePlane.GetComponent<Renderer> ().material.mainTexture = demotex;


		//imagePlane.transform.localScale = new Vector3(0.008f, 0.008f, 0.005f);
		imagePlane.transform.localScale = new Vector3(0.008f, 0.008f, 0.005f);
		//imagePlane.transform.localScale = new Vector2(0.01f, 0.015f);
		imagePlane.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);
		imagePlane.transform.parent = cube.transform;
		//imagePlane.transform.SetPositionAndRotation (imagePlane.transform.parent.position, imagePlane.transform.parent.localRotation);
		imagePlane.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		imagePlane.transform.localEulerAngles = new Vector3 (90f, 0f, 180f);
		imagePlane.transform.Translate (0.0f, -0.2f, 0.0f);

		//Texture demotex = gameObject.GetComponent<Texture>();
		//Texture demotex = gameObject.GetComponentInChildren<Renderer>().material.GetTexture("_MainTex") as Texture;
		//cube.GetComponent<Renderer> ().material.mainTexture = demotex;
		//imagePlane.GetComponent<Renderer> ().material.mainTexture = demotex;

		//Texture demotex = Resources.Load (texName) as Texture;
		//

		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		dispText2.text = gameObject.name + "; " + imagePlane.transform.parent.name;

		//
		imagePlane.gameObject.SetActive(true);
		cube.gameObject.SetActive(true);
		DestroyObject (GameObject.Find(currentTextureName));

	}
}
