using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelPopsup : MonoBehaviour {

	private bool mAddModel = false;
	public Text demoLable; 


	public UnityEngine.UI.Text dispText2;

	//void OnGUI() {
	//	if (GUI.Button(new Rect(50,50,200,100), "Add Cube")) {
	//		mAddModel = true;
	//		Debug.Log ("POP");
	//	}
	//}

	// Update is called once per frame
	void Update () {
		if (mAddModel) {
			Debug.Log ("Adding model...");

			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

			cube.transform.parent = this.gameObject.transform;

			// Adjust scale and position 
			// (use localScale and localPosition to make it relative to the parent)
			cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			cube.transform.localPosition = new Vector3(0, 0.3f, 0);
			cube.transform.localRotation = Quaternion.identity;

			cube.gameObject.SetActive(true);

			mAddModel = false;
		}
	}

	public void createCube () {
		Debug.Log ("Adding model...");

		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		//cube.transform.parent = this.gameObject.transform;



		// Adjust scale and position 
		// (use localScale and localPosition to make it relative to the parent)
		cube.transform.localScale = new Vector3(0.1f, 0.15f, 0.015f);
		//cube.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, GameObject.Find("ImageTarget").gameObject.transform.position.z);
		cube.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);
		//cube.transform.localPosition = new Vector3(0, 0, 0);
		//cube.transform.localRotation = Quaternion.identity;

		cube.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		cube.transform.Translate (0.0f, 0.0f, 0.2f);
		//cube.transform.localPosition = cube.transform.localPosition + new Vector3 (0, 0, 0.2f);
		//cube.transform.localRotation = Quaternion.Euler(new Vector3(Camera.allCameras[0].transform.rotation.x, Camera.allCameras[0].transform.rotation.y, Camera.allCameras[0].transform.rotation.z));

		//cube.transform.parent = GameObject.Find("ImageTargetFlausch").gameObject.transform;

		//Same as above, except this makes the player keep its local orientation rather than its global orientation.
		//Transform imgTargt = GameObject.Find("ImageTargetFlausch").gameObject.transform;
		//cube.transform.SetParent (imgTargt, false);

		Texture demotex = Resources.Load ("DemoDocTexture") as Texture;
		cube.GetComponent<Renderer> ().material.mainTexture = demotex;

		cube.gameObject.SetActive(true);

	}

	public void createSelectedPage (string texName) {
		Debug.Log ("Adding model...");

		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject imagePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);

		// Adjust scale and position 
		// (use localScale and localPosition to make it relative to the parent)
		cube.transform.localScale = new Vector3(0.1f, 0.15f, 0.015f);
		cube.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);
		cube.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		cube.transform.Translate (0.0f, 0.0f, 0.21f);


		imagePlane.transform.localScale = new Vector3(0.008f, 0.008f, 0.005f);

		//imagePlane.transform.localScale = new Vector2(0.01f, 0.015f);
		imagePlane.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);
		imagePlane.transform.parent = cube.transform;
		//imagePlane.transform.SetPositionAndRotation (imagePlane.transform.parent.position, imagePlane.transform.parent.localRotation);
		imagePlane.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		imagePlane.transform.localEulerAngles = new Vector3 (90f, 0f, 180f);
		imagePlane.transform.Translate (0.0f, -0.2f, 0.0f);

		//Texture demotex = gameObject.GetComponent<Texture>();
		Texture demotex = Resources.Load (texName) as Texture;
		//cube.GetComponent<Renderer> ().material.mainTexture = demotex;
		imagePlane.GetComponent<Renderer> ().material.mainTexture = demotex;

		//

		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		dispText2.text = gameObject.name + "; " + imagePlane.transform.parent.name;

		//
		imagePlane.gameObject.SetActive(true);
		cube.gameObject.SetActive(true);

	}
}