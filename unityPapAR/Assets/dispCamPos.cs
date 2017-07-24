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
		dispText = GameObject.Find("Texti").GetComponent<UnityEngine.UI.Text>();
		dispText.text = "KamPos: " + x + ",\n     y:   " + y + ", \n    z:     " + z;
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
