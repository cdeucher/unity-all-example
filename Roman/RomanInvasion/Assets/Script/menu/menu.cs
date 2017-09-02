using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	public Texture2D background;
	public Texture2D titulo;


	void OnGUI(){
		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height), background);
		//GUI.DrawTexture (225,50,150,40,titulo);

		GUI.BeginGroup (new Rect((Screen.width/2)-110,(Screen.height/2)-110,250,250));
		GUI.Box (new Rect(0,0,250,250),"Menu");
		if (GUI.Button (new Rect (50, 30, 150, 50), "One - Iniciar")) {
			Application.LoadLevel ("one");
		}
		if (GUI.Button (new Rect (50, 85, 150, 50), "Two - Iniciar")) {
			Application.LoadLevel ("rush");
		}
		if (GUI.Button (new Rect (50, 140, 150, 50), "Sair")) {
			Application.Quit();	
		}			
		GUI.EndGroup();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
