using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private string[] indexlevel = {"MainLevel","MainLevel","MainLevel2","MainLevel3","MainLevel4","MainLevel5","MainLevel6"};

	private bool gameHasEnded = false;

	public Rotator rotator;
	public Spawner spawner;

	public Animator animator;

	public void EndGame ()
	{
		if (gameHasEnded)
			return;
		animator.SetTrigger("EndGame");

		FindObjectOfType<Rank>().clickSet();
		if(rotator)
		rotator.enabled = false;
		if(spawner)
		spawner.enabled = false;	

		gameHasEnded = true;
	}
	public void RestartLevel ()
	{
	    if(Rank.Level >= 6)
			SceneManager.LoadScene(indexlevel[6]);	
		else	
	 	    SceneManager.LoadScene(indexlevel[Rank.Level]);
	}


}
