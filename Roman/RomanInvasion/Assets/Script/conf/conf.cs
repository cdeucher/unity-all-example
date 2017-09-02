using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conf : MonoBehaviour {

	public Texture2D soldier;
	public bool activate = false;

	void OnGUI(){
		if (activate) {
			GUI.BeginGroup (new Rect ((Screen.width / 2) - 110, (Screen.height / 2) - 110, 250, 250));
			GUI.Box (new Rect (0, 0, 250, 250), "Custom");

			GUI.DrawTexture (new Rect (0, 0, 250, 250), soldier);

			GUI.EndGroup ();
		}
	}
}
