using UnityEngine;
using System.Collections;

public class exitPlay : MonoBehaviour {

	public void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
	}

}