using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

	public Player Iam;
	public GameObject arrow;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AnimationAttack(){
		//Debug.Log ("AnimationAttack");

		//FindObjectOfType<Player> ();
		if (Iam.Enemy != null) {
			try{	
				Iam.Enemy.SendMessage ("setLife", Iam, SendMessageOptions.DontRequireReceiver);
			}catch(System.FormatException  e){
				Debug.Log (e);
			}
		}else
			Iam.cancelAttack ();	
	} 
	void AnimationAttackArquer(){
	    Debug.Log ("AnimationAttackArquer");

		//FindObjectOfType<Player> ();
		if (Iam.Enemy != null) {
			//Iam.Enemy.SendMessage ("setLife", Iam);
           
			this.Shoot ();
		}else
			Iam.cancelAttack ();	
	} 
	void Shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate(arrow, transform.position, transform.rotation);
		Arrow bullet = bulletGO.GetComponent<Arrow>();

		if (bullet != null)
			bullet.Seek(Iam.Enemy, Iam);
	}
}
