using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readFiles : MonoBehaviour {

	//UI Elements:
	public GameObject menU;
	public uiAction menuControl;
	public floatingPage pageControl;
	public GameObject docListContainer;
	public GameObject listElPre;

	// Use this for initialization
	void Start () {
		menU = GameObject.Find ("MenuUICanvas");
		menuControl = menU.GetComponent<uiAction> ();
		pageControl = menU.GetComponent<floatingPage> ();
		docListContainer = menU.transform.Find ("DocList").gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
		displayTextures ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void displayTextures(){
		//var textures = Resources.LoadAll("", typeof(Texture2D));
		var textures = Resources.LoadAll("dummydocs", typeof(Sprite));
		//GameObject docContainer = GameObject.Find ("DocListButtons");

		//docListContainer = GameObject.Find ("DocumentListContent");
		Debug.Log ("HELLO?!?!" + textures.Length);
		if (docListContainer.transform.childCount < 2 ){
			foreach (Sprite tex in textures) {
				//Debug.Log (tex.name);
				//Sprite docTex = Resources.Load (tex.name) as Sprite;
				//var pagePanel = GUIElement.Instantiate (GameObject.Find ("PagePreviewPanel"), docContainer.transform);
				//pagePanel.GetComponent<Image> ().sprite = tex;
				//pagePanel.name = tex.name;
				
				//var btn = GUIElement.Instantiate (GameObject.Find ("PageButton"), docContainer.transform);
				var doc = GUIElement.Instantiate (listElPre, docListContainer.transform);
				var btn = doc.transform.GetChild (0);
				btn.GetComponent<Image> ().sprite = tex;
				btn.name = tex.name;
				var docName = doc.transform.GetChild (1).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
				docName.text = tex.name;
				//var btn = GUIElement.Instantiate(GameObject.Find("Button"), docContainer.transform);
				//Texture docTex = Resources.Load (tex.name) as Texture2D;
				//btn.GetComponent<Image> ().material.mainTexture = docTex;
				//Button bt = btn.GetComponent<Button>();
				//bt.onClick.AddListener (executeClic);
				//btn.transform.GetChild(0).GetComponent<RawImage> ().texture = Resources.Load (tex.name) as Texture2D;
				//Debug.Log ("?!?! " + btn.transform.GetChild (0).GetComponent<RawImage> ().texture.wrapMode);

			}
			//GameObject.Destroy (GameObject.Find ("PageButton"));
			//GameObject.Destroy (GameObject.Find ("DocumentPanel"));
			GameObject.Destroy (listElPre);
		}
	}

	public void executeClic (){
		Debug.Log ("Bisher " + gameObject.name);
		//pageControl.dropOldPage ();
		pageControl.takePage (gameObject.name);
		menuControl.closeMenu ();
	}
}
