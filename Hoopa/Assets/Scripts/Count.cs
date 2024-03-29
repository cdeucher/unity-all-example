﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {
	
	public Text text;
	public Text Timer;
	public Text Level;

	public static float timer = 40f;

	public void Set (string a,string b) {
		text.text = a+"/"+b;
	}
	public void SetLevel (string a) {
		Level.text = "Level "+a;
	}

	public void restart(){
		if (Rank.Level < 3)
			timer = 20f;
		else {
			timer = 20f;			
		}
	}
	void Start(){
		restart ();
	}
	void Update(){
		timer -= Time.deltaTime;
		Timer.text = Mathf.FloorToInt (timer).ToString () + "s";
		if (timer <= 0f) {			
			restart ();
			FindObjectOfType<GameManager> ().EndGame ();
		}
	}	
}
