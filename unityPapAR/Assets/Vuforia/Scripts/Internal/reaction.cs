﻿using UnityEngine;
using System.Collections;

public class reaction : MonoBehaviour {

	bool isHighlighted = false;
	Material originalMaterial;
	Material redMaterial;
	MeshRenderer meshRenderer;

	GameObject baseObject;
	string obj_name;
	// Use this for initialization
	void Start () {

		obj_name 			= this.gameObject.name + "Base";
		baseObject 			= GameObject.Find( obj_name );
		meshRenderer 		= baseObject.GetComponent<MeshRenderer>();
		originalMaterial 	= meshRenderer.material;

		Color red 			= new Color(255.0f,0.0f,0.0f, 0.5f);
		redMaterial  		= new Material(Shader.Find("Transparent/Parallax Specular"));
		redMaterial.color 	= red;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){

		Debug.Log("OMD "+obj_name);
		isHighlighted = !isHighlighted;

		if( isHighlighted ){

			HighlightRed();

		}else{

			RemoveHighlight();
		}
	}

	void HighlightRed(){

		meshRenderer.material = redMaterial;
	}

	void RemoveHighlight(){

		meshRenderer.material = originalMaterial;
	}
}