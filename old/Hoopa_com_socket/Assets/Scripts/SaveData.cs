using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

	public void Save(){
		//save data
		FindObjectOfType<SaveData> ().SetRank (Rank.Level,Rank.Current,Rank.go);
	}

	public void SetRank (int Level, int Current,int[] go) {
		PlayerPrefs.SetInt ("Level",Level);
		PlayerPrefs.SetInt ("Current",Current);
		PlayerPrefs.SetInt ("Go0",go[1]);
		PlayerPrefs.SetInt ("Go1",go[2]);
		PlayerPrefs.SetInt ("Go2",go[3]);
	}
	public int[] GetRank () {
		int[] load = {PlayerPrefs.GetInt ("Level"),PlayerPrefs.GetInt ("Current")
			,PlayerPrefs.GetInt ("Go1")
			,PlayerPrefs.GetInt ("Go2")
			,PlayerPrefs.GetInt ("Go3")
		};
		return load;
	}	
	public void ResetRank () {
		PlayerPrefs.SetInt ("Level",1);
		PlayerPrefs.SetInt ("Current",1);
		PlayerPrefs.SetInt ("Go1",0);
		PlayerPrefs.SetInt ("Go2",0);
		PlayerPrefs.SetInt ("Go3",0);
	}	

}
