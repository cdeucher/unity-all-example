using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public float life = 10;
	public float forca = 1;
	public float defesa = 2;
	public float range = 15f;

	public Transform spritePlayer;
	public Transform lifePlayer;
	public GameObject Enemy;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator> ();
		if (spritePlayer.tag == "archer")
			InvokeRepeating ("updateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag == "Player"){
			Movimentacao ();
	    }else {
			AutoMove ();
		}
	}
	void AutoMove() {
		if (!animator.GetBool ("attak")) {
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			animator.SetBool ("walk", true);
		}
		if (transform.localPosition.x < -7) {
			kill ();
		}
	}
	void Movimentacao() {
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
			animator.SetBool ("walk", true);
		} else if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
			animator.SetBool ("walk", true);
		} else if (Input.GetAxisRaw("Vertical") > 0 ) {
			transform.Translate (Vector2.up * speed * Time.deltaTime);
			animator.SetBool ("walk", true);
		}else if (Input.GetAxisRaw("Vertical") < 0 ) {
			transform.Translate (Vector2.down * speed * Time.deltaTime);
			animator.SetBool ("walk", true);
		} else {
			animator.SetBool ("walk",false);
		}
	} 

	public void setLife(Player Soldier){
		float tmp = Soldier.forca - this.defesa;
		life -= (tmp < 0) ? 0 : tmp;
		//Debug.Log (life);
		if (life <= 0) {
			Soldier.cancelAttack ();
			kill ();
		} else {
			lifePlayer.transform.localScale = new Vector3 (( (life / 20))
				, lifePlayer.localScale.y
				, lifePlayer.localScale.z);
		}	
	}
	float getLife(){
		return life;		
	}
	void updateTarget(){
		GameObject [] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nereastEnemy = null;

		foreach(GameObject enemy in enemys){
			float distanceToEnemy = Vector3.Distance (transform.position,enemy.transform.position);
			if( distanceToEnemy <  shortestDistance){
				shortestDistance = distanceToEnemy;
				nereastEnemy = enemy;
			}
		}
		if(nereastEnemy != null && shortestDistance <= range ){
			this.startAttack(nereastEnemy);
		}else{
			Enemy = null;
		}
	}
	void kill(){
		Destroy ( gameObject );
	}
	public void startAttack(GameObject enemy){
		Enemy = enemy;
		animator.SetBool ("attak", true);
	}
	public void cancelAttack(){
		//Debug.Log ("Exit attak");
		animator.SetBool ("attak", false);
		animator.SetBool ("stop", true);
		animator.Play ("stop");
	}
	void OnTriggerEnter2D (Collider2D enemy)
	{         
		if (enemy.tag != gameObject.tag ) {
			//Debug.Log ("attak");
			startAttack (enemy.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{         			
		cancelAttack ();
	}
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position,range);
	}
}
