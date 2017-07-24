using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelPopsup : MonoBehaviour {

	private bool mAddModel = false;
	public Text demoLable; 


	void OnGUI() {
		if (GUI.Button(new Rect(50,50,200,100), "Add Cube")) {
			mAddModel = true;
			Debug.Log ("POP");
		}
	}

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
		cube.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, GameObject.Find("ImageTargetFlausch").gameObject.transform.position.z);
		//cube.transform.localPosition = new Vector3(0, 0, 0);
		cube.transform.localRotation = Quaternion.identity;

		//cube.transform.parent = GameObject.Find("ImageTargetFlausch").gameObject.transform;

		//Same as above, except this makes the player keep its local orientation rather than its global orientation.
		//Transform imgTargt = GameObject.Find("ImageTargetFlausch").gameObject.transform;
		//cube.transform.SetParent (imgTargt, false);

		Texture demotex = Resources.Load ("DemoDocTexture") as Texture;
		cube.GetComponent<Renderer> ().material.mainTexture = demotex;

		cube.gameObject.SetActive(true);

	}
}