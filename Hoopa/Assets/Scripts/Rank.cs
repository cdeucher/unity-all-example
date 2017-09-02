using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Rank : MonoBehaviour {

	public static int Level = 1;
	public static float Media = 0;

	public static bool isReload = false;

	public static int[] go  = new int[6];
	public static int Current = 1;
	public static int Max = 3;
	public static float timer = 0.7f;
	public static bool StartEnd = false;


	public void clickSet(){

		FindObjectOfType<Count>().Set(Current.ToString(),Max.ToString());
		//set current score
		go[Current] = Score.PinCount;	

		if (Current >= Max) {			
			StartEnd = true;
			//SceneManager.LoadScene("Rank");

			Current = 0;
		}
		Current++;
	}
	public void openOnline(){
		SceneManager.LoadScene("RankOnline");
	}
	public void Sair(){
		Application.Quit ();
	}
	public void openService(){
		SceneManager.LoadScene("GameService");
	}

	void Update(){
		if (StartEnd == true) {

			timer -= Time.deltaTime;
			if(timer <= 0){				
				StartEnd = false;
				SceneManager.LoadScene("Load");
			}
		}
	}
	void Start(){
		if (GameObject.Find ("rank1")) {
			StartEnd = false;
			timer = 0.7f;
			GameObject.Find ("rank1").GetComponentInChildren<Text> ().text = "Rodada 1  "+go [1].ToString ();
			GameObject.Find ("rank2").GetComponentInChildren<Text> ().text = "Rodada 2  "+go [2].ToString ();
			GameObject.Find ("rank3").GetComponentInChildren<Text> ().text = "Rodada 3  "+go [3].ToString ();

			float tmp = 0;
			for (int i = 0; i <= Max; i++) {
				tmp += go [i];
			}
			//tmp = 150;
			Media = Mathf.Round (tmp / Max);
			GameObject.Find ("media").GetComponentInChildren<Text> ().text = Mathf.Round (Media).ToString ();
			if (isReload == false) {
				if ( Mathf.Round (Media)  >= (10 + Level)) {
					Level++;
					GameObject.Find ("levelUp").GetComponentInChildren<Text> ().text = "Próximo: " + Level;	
				} else {
					GameObject.Find ("levelUp").GetComponentInChildren<Text> ().text = "Necessário: " + (10 + Level);	
				}
			} else {
				GameObject.Find ("levelUp").GetComponentInChildren<Text> ().text = "RELOAD: " + Level;
				isReload = false;
			}

		} else {
			FindObjectOfType<Count>().Set(Current.ToString(),Max.ToString());
			FindObjectOfType<Count>().SetLevel(Level.ToString());
		}
	}	

}
