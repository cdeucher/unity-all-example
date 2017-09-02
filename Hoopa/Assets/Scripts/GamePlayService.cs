using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class GamePlayService : MonoBehaviour {

	public Text debug;

	private string[] indexLevel = {"CgkI16OukMcPEAIQAQ","CgkI16OukMcPEAIQAQ","CgkI16OukMcPEAIQAg","CgkI16OukMcPEAIQAw","CgkI16OukMcPEAIQBA","CgkI16OukMcPEAIQBQ","CgkI16OukMcPEAIQCA"};
	private string[] indexPlacar= {"CgkI16OukMcPEAIQBg","CgkI16OukMcPEAIQBg","CgkI16OukMcPEAIQCQ","CgkI16OukMcPEAIQCg","CgkI16OukMcPEAIQCw","CgkI16OukMcPEAIQDA","CgkI16OukMcPEAIQDQ"};

	void Start()
	{
		PlayGamesPlatform.Activate();
		ativate ();
	}
	void ativate(){
		Social.localUser.Authenticate((bool success) =>{
			if (success){
				debug.text = "You've successfully logged in";

				//conquistas();
			}else{
				debug.text = "Login failed for some reason";
			}
		});
	}

	public void conquistas(){
		if (Social.localUser.authenticated){
			//mostra conquistas
			Social.ShowAchievementsUI ();
		}
	}
	public void placar(){
		if (Social.localUser.authenticated){
			//mostra Placar
			Social.ShowLeaderboardUI();
		}
	}

	public void set1(){
		Debug.Log (PlayerPrefs.GetInt ("Level"));
	
		if (Social.localUser.authenticated){
			Social.ReportProgress(indexLevel[PlayerPrefs.GetInt ("Level")], 100f , (bool success) =>{
					if (success){
					   debug.text = "Level liberado!";
					}else{
					   debug.text = "Level não liberado!";
					}
			});
		}
	}

	public void setPlacar(){
		if (Social.localUser.authenticated){
			Social.ReportScore( Mathf.FloorToInt(Rank.Media), indexPlacar[PlayerPrefs.GetInt ("Level")], (bool success) =>
				{
					if (success)
					{
						((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(indexPlacar[Rank.Level]);
						debug.text = "Placar liberado!";
					}
					else
					{
						debug.text =  "Placar não liberado!";
					}
				});
		}
	}
		
}
