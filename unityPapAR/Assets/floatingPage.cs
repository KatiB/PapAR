using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Touch;

public class floatingPage : MonoBehaviour {


	//UI Elements:
	public GameObject menU;
	public uiAction menuControl;
	public UnityEngine.UI.Text dispText2;

	//Game Elements:
	public Camera arCam;

	//Variables:
	public string currentTextureName = "DemoDocTexture";
	public int docCount = 0;
	public float pageWidth = 1f;
	public float pageHight = 1f;
	public float pageVol = 0.008f;
	public bool threeD = true;

	// Use this for initialization
	void Start () {
		menU = GameObject.Find ("MenuUICanvas");
		menuControl = menU.GetComponent<uiAction> ();
		arCam = Camera.allCameras [0];

	}

	// Update is called once per frame
	void Update () {
		
		RaycastHit hit = new RaycastHit();
		for (int i = 0; i < LeanTouch.Fingers.Count; ++i) {
			Debug.Log ("clickupdate............." + i);
			//if (Input.GetTouch (i).phase.Equals (TouchPhase.Ended)) {
			//if (!LeanTouch.Fingers[i].StartedOverGui && LeanTouch.Fingers[i].Up && LeanTouch.Fingers[i].Tap) {
			if (!LeanTouch.Fingers[i].StartedOverGui && LeanTouch.Fingers[i].Tap) {
					Debug.Log ("LEAN OFF"); // + LeanTouch.Fingers[i].LastScreenPosition);
					// Construct a ray from the current touch coordinates
				//Ray ray = arCam.ScreenPointToRay (Input.GetTouch (i).position);
				Ray ray = arCam.ScreenPointToRay (LeanTouch.Fingers[i].ScreenPosition);

				if (Physics.Raycast(ray, out hit)) {
					//hit.transform.gameObject.SendMessage("OnMouseDown");
					var clickTarget = hit.transform.name;
					var clickObject = hit.collider.name;
					Debug.Log ("HiT!!!" + clickTarget);
					dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
					dispText2.text = "Clicked " + clickTarget + ", " + clickObject;
				}

				handleClick (ray, hit); //http://answers.unity3d.com/questions/332085/how-do-you-make-an-object-respond-to-a-click-in-c.html
			}
			/**if (LeanTouch.Fingers [i].Swipe) {
				var floatPage = GameObject.Find ("floatingImg");
				floatPage.transform.Translate (Vector3.left * Time.deltaTime, arCam.transform);
				DestroyObject (floatPage);

			}**/

			if (LeanTouch.Fingers [i].IsOverGui && LeanTouch.Fingers[i].Up) {
				Debug.Log ("LEAN ON UI");
				//Debug.Log ("Hit? " + hit.collider.name);
				//if (hit.collider.gameObject.transform.parent == GameObject.Find ("DocListButtons")) {
				//}
			}

		}
		/**
		Debug.Log ("clickupdate2.............");
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Mouse Down! MIAU!");
			Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
			if (!EventSystem.current.IsPointerOverGameObject()) {
				handleClick (ray, hit);
				}
		}
		**/
	}

	public void handleClick (Ray ray, RaycastHit hit){
		if (Physics.Raycast(ray, out hit)) {
			//hit.transform.gameObject.SendMessage("OnMouseDown");
			var clickTarget = hit.collider.gameObject;
			var clickObject = hit.collider.name;
			Debug.Log ("Object : " + clickObject);
			Debug.Log ("Parent : " + clickTarget.transform.parent.name);

			//
			dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
			var texName = hit.collider.gameObject.GetComponentInChildren<Renderer> ().material.mainTexture.name;
			dispText2.text = "Clicked " + clickTarget.transform.parent.name + ", " + clickObject + ", " + texName;
			//
			if (clickTarget.name == "MenuButton"){
				return;
			}
			if (clickTarget.transform.parent.transform.parent.name == "ImageTarget") {
				var scriptHolderObject = GameObject.FindObjectOfType (typeof(floatingPage)) as floatingPage; //https://forum.unity3d.com/threads/calling-function-from-other-scripts-c.57072/
				Debug.Log ("Bis hier her!!!");
				scriptHolderObject.takePage (texName);

				//var mainMen = GameObject.Find ("Menu");
				menuControl.closeMenu ();
				//	mainMen.SetActive (false);
				//	var menuButton = GameObject.Find ("MenuUICanvas").transform.Find ("MenuButton").gameObject;
				//	menuButton.SetActive (true);

				DestroyObject (clickTarget.transform.parent.gameObject);
			}
			if (clickTarget.name == "floatingImg") {
				createSelectedPage (clickTarget);
				AudioSource audio = gameObject.GetComponent<AudioSource>();
				audio.PlayOneShot(Resources.Load<AudioClip>("Sounds/paperrustle"));	//!!Quelle
				DestroyObject (GameObject.Find("floatingImg"));
				//dispText2.text = "Clicked on Floating Page";

			}

			addInfo (clickObject);
		}
	}

	public void addInfo(string clckPage){
		Debug.Log ("Display Infos...");
		/**
		GameObject clickedPage =  GameObject.Find (clckPage);
		GameObject lable = GameObject.CreatePrimitive(PrimitiveType.Plane);
		lable.transform.parent = clickedPage.transform;
		lable.transform.localEulerAngles = new Vector3 (90.0f, 0.0f, 180.0f);
		lable.transform.localPosition = new Vector3 (0.05f, 0f, 0f);
		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		dispText2.text = "Lable: " + lable.transform.parent.name;
		**/

	}

	public void setPalcementMode (bool threed){
		threeD = threed;
	}

	public void takePage (string texName) {
		currentTextureName = texName;
		//Texture demotex = Resources.Load (currentTextureName) as Texture;
		dropOldPage ();
		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		//GameObject floatingImgBtn = gameObject.transform.Find ("activePageButton").gameObject;
		//GameObject floatingImg = floatingImgBtn.transform.Find ("ActiveImagePanel").gameObject;

		//dispText2.text = gameObject.name + "; " + texName + "; " + floatingImg.name;
		//gameObject.GetComponent<Renderer> ().material.mainTexture = demotex;
		//gameObject.GetComponent<Renderer> ().material.mainTexture = demotex;
		//floatingImg.gameObject.SetActive(true);
		GameObject floatingImagePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		GameObject floatingImagePlaneBackground = GameObject.CreatePrimitive(PrimitiveType.Plane);

		Texture demotex = Resources.Load (currentTextureName) as Texture;

		Material floatMat = Resources.Load("floatingMat", typeof(Material)) as Material;
		floatingImagePlane.GetComponent<Renderer> ().material = floatMat;


		//var height = 2.0f * Mathf.Tan(0.5f * Camera.allCameras[0].fieldOfView * Mathf.Deg2Rad) + 0.4f;
		//var width = height * Screen.width / Screen.height;

		var height = 2.0f * Mathf.Tan (0.5f * arCam.fieldOfView * Mathf.Deg2Rad) + 0.4f;
		var width = height * Screen.width / Screen.height;

		if (Screen.width < Screen.height) {
			var sizeDiff = width / demotex.width;
			pageWidth = width;
			pageHight = demotex.height * sizeDiff;
		} else {
			var sizeDiff = height / demotex.height;
			pageHight = height;
			pageWidth = demotex.width * sizeDiff;
		}


		floatingImagePlane.GetComponent<Renderer> ().material.mainTexture = demotex;
		floatingImagePlane.name = "floatingImg";

		floatingImagePlane.transform.localScale = new Vector3(pageWidth/100f, 1.0f, pageHight/100f );

		//floatingImagePlane.transform.localPosition = new Vector3(Camera.allCameras[0].transform.position.x, Camera.allCameras[0].transform.position.y, Camera.allCameras[0].transform.position.z);

		floatingImagePlane.transform.parent = Camera.allCameras[0].transform;

		//floatingImagePlane.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		floatingImagePlane.transform.localEulerAngles = new Vector3 (90f, 0f, 180f);
		//floatingImagePlane.transform.Translate (0.0f, -0.2f, 0.0f);
		floatingImagePlane.transform.localPosition = new Vector3 (0, 0, 0.2f);
		//floatingImagePlane.transform.SetPositionAndRotation (floatingImagePlane.transform.parent.position, floatingImagePlane.transform.parent.localRotation);


		//floatingImagePlane.AddComponent<LeanTouchEvents> ();
		//var tevent = floatingImagePlane.GetComponent<LeanTouchEvents> ();
		dispText2.text = "Event: " + LeanGesture.GetPinchScale();
		floatingImagePlane.AddComponent<LeanScale> ();
		var scaler = floatingImagePlane.GetComponent<LeanScale> ();
		scaler.Relative = true;
		floatingImagePlane.AddComponent<LeanTranslate> ();
		var translator = floatingImagePlane.GetComponent<LeanTranslate> ();


		scaler.Scale (1.0f, LeanGesture.GetLastScreenCenter());
		//Color backGr = new Color (0.28f, 0.44f, 0.48f, 0.05f);
		//Color backGr = new Color32 (72, 112, 123, 128);
		//floatingImagePlaneBackground.GetComponent<Renderer> ().material.SetColor ("_Color", backGr);

		Material newMat = Resources.Load("backgroundMaterial", typeof(Material)) as Material;
		floatingImagePlaneBackground.GetComponent<Renderer> ().material = newMat;


		floatingImagePlaneBackground.name = "floatingImgBackground";
		floatingImagePlaneBackground.transform.localScale = new Vector3 (Screen.width * 3, 1.0f, Screen.height * 3);
		floatingImagePlaneBackground.transform.parent = floatingImagePlane.transform;
		//floatingImagePlaneBackground.transform.parent = Camera.allCameras[0].transform;
		floatingImagePlaneBackground.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		floatingImagePlaneBackground.transform.localPosition = new Vector3 (0.0f, -0.20001f, 0.0f);

		//floatingImagePlaneBackground.transform.localEulerAngles = Camera.allCameras[0].transform.eulerAngles;
		//floatingImagePlaneBackground.transform.localEulerAngles = new Vector3 (90f, 0f, 180f);
		//floatingImagePlaneBackground.transform.Translate (0.0f, -0.2f, 0.0f);


		floatingImagePlaneBackground.GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		floatingImagePlaneBackground.GetComponent<Renderer> ().receiveShadows = false;

		//
		floatingImagePlane.gameObject.SetActive(true);

	}

	public void createSelectedPage (GameObject selectedPage) {
		Debug.Log ("Placeing a Page...");
		AudioSource paperaudio = GetComponent<AudioSource>();
		paperaudio.Play();
		Handheld.Vibrate ();
		docCount = ++docCount;
		string docName = "Document" + docCount;
		Material mat = Resources.Load("floatingMat", typeof(Material)) as Material;
		GameObject ImgTarget = GameObject.Find ("ImageTarget");
		Plane targetPlane = new Plane (ImgTarget.transform.up, ImgTarget.transform.position);
		GameObject docVolume = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject imagePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		imagePlane.GetComponent<Renderer> ().material = mat;
		//Texture demotex = Resources.Load (currentTextureName) as Texture;
		Texture demotex = Resources.Load (selectedPage.GetComponent<Renderer> ().material.mainTexture.name) as Texture;
		var height = 2.0f * Mathf.Tan(0.5f * Camera.allCameras[0].fieldOfView * Mathf.Deg2Rad) + 0.4f;
		var width = height * Screen.width / Screen.height;
		Vector3 pagePos = new Vector3 (arCam.transform.position.x, arCam.transform.position.y, arCam.transform.position.z);
		Vector3 pageAngle = arCam.transform.eulerAngles;
		Vector3 coverAngle = new Vector3 (90.0f, 0.0f, 180.0f);
		Vector3 pageDist = new Vector3 (0.0f, 0.0f, 0.21f);
		float camRotY = arCam.transform.eulerAngles.y;

		if (!threeD) {
			foreach (LeanFinger touch in LeanTouch.Fingers) {
				Ray ray = arCam.ScreenPointToRay (touch.ScreenPosition);
				float dist = 0.0f;
				targetPlane.Raycast (ray, out dist);
				pagePos = ray.GetPoint (dist);
			}
			pageAngle = new Vector3 (90.0f, camRotY, 0.0f);
			pageDist = new Vector3 (0.0f, 0.0f, 0.0f);
		}

		docVolume.transform.localScale = new Vector3(pageWidth/10f, pageHight/10f, pageVol);
		docVolume.transform.localPosition = pagePos;
		docVolume.transform.localEulerAngles = pageAngle;
		docVolume.transform.Translate (pageDist);
		docVolume.name = docName;
		docVolume.transform.parent = GameObject.Find("ImageTarget").transform;


		imagePlane.transform.parent = docVolume.transform;
		//imagePlane.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		imagePlane.transform.localEulerAngles = coverAngle;
		float coverDist = 0.501f;
		//imagePlane.transform.Translate (0.0f, coverDist, 0.0f);
		imagePlane.transform.localPosition = new Vector3 (0.0f, 0.0f, -coverDist);
		imagePlane.transform.localScale = new Vector3 (0.1f, 1f, 0.1f);

		imagePlane.name = "Front" + docName;

		imagePlane.GetComponent<Renderer> ().material.mainTexture = demotex;

		//

		dispText2 = GameObject.Find("Texti2").GetComponent<UnityEngine.UI.Text>();
		//dispText2.text = gameObject.name + "; " + imagePlane.transform.parent.name;

		//
		//DestroyObject (GameObject.Find("floatingImg"));
		imagePlane.gameObject.SetActive(true);
		docVolume.gameObject.SetActive(true);

	}

	public void dropOldPage (){
		GameObject.Destroy (GameObject.Find ("floatingImg"));
	}
}