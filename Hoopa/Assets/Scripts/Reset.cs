using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {


	public void ResetLVL ()
	{
		if (Rank.Current == 1) {
			Debug.Log ("RESET LVL");
			Rank.Level = 1;
			FindObjectOfType<GameManager> ().RestartLevel ();

		} else {
			Debug.Log ("RESET CURRENT");
			Rank.Current = 1;
			FindObjectOfType<GameManager> ().RestartLevel ();
		}
	}
	public void LoadLVL ()
	{
			Debug.Log ("LOAD LVL");
		    int[] tmp = FindObjectOfType<SaveData> ().GetRank ();
		    Rank.Level = tmp[0];
		    Rank.Current = tmp[1];
		    Rank.go[1] = tmp[2];
			Rank.go[2] = tmp[3];
			Rank.go[3] = tmp[4];

			//FindObjectOfType<GameManager> ().RestartLevel ();
		    Rank.isReload = true;
		   SceneManager.LoadScene("Rank");
	}
}
