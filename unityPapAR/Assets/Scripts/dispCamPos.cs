using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispCamPos : MonoBehaviour {

	public UnityEngine.UI.Text dispText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Camera.allCameras[0].transform.position.x;
		float y = Camera.allCameras [0].transform.position.y;
		float z = Camera.allCameras [0].transform.position.z;
		//get Camera orientation
		float rotX = Camera.allCameras[0].transform.rotation.x;
		float rotY = Camera.allCameras [0].transform.rotation.y;
		float rotZ = Camera.allCameras [0].transform.rotation.z;
		dispText = GameObject.Find("Texti").GetComponent<UnityEngine.UI.Text>();
		dispText.text = "KamPos: " + x + ",\n     y:   " + y + ", \n    z:     " + z + "\n\n" +"KamRot: " + rotX + ",\n     rotY:   " + rotY + ", \n    rotZ:     " + rotZ;

	}

	public void changeText () {
		Debug.Log ("KameraPos:" + Camera.allCameras[0].transform.position.ToString());
		//string messageText = "KameraPos:" + Camera.allCameras [0].transform.position.ToString ();
		//this.changeText (messageText);
		float x = Camera.allCameras[0].transform.position.x;
		float y = Camera.allCameras [0].transform.position.y;
		float z = Camera.allCameras [0].transform.position.z;
		dispText = GameObject.Find("Texti").GetComponent<UnityEngine.UI.Text>();
		//dispText.text = "KameraPos:" + Camera.allCameras[0].transform.position.ToString();
		dispText.text = "KamPos: " + x + ", " + y + ", " + z;
	}
}
