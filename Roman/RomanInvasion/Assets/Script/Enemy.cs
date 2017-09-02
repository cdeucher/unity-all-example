using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;
	public float life = 10;
	public Transform spritePlayer;
	public Transform lifePlayer;
	//public Player Enemy;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setLife(Player Soldier){
		life -= Soldier.forca;
		Debug.Log (life);
		if (life <= 0) {
			Soldier.cancelAttack ();
			kill ();
		} else {
			lifePlayer.transform.localScale = new Vector3 ((lifePlayer.localScale.x - (Soldier.forca / 20))
			, lifePlayer.localScale.y
			, lifePlayer.localScale.z);
		}	
	}
	float getLife(){
		return life;		
	}
	void kill(){
		Destroy ( gameObject );
	}

	void OnTriggerEnter2D (Collider2D col)
	{         
		if (col.tag == "Enemy") {
			Debug.Log ("attak");
			//Enemy.transform.SetParent (col.transform);

			animator.SetBool ("attak", true);
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{         
			Debug.Log ("Exit attak");
			animator.SetBool ("attak", false);
	}
}
