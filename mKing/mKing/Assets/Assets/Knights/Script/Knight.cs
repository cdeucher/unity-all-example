using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

	Animator animator;

	private Transform target;
	private Vector3 Step;

	public  float speed = 0.3f;
	public  float range = 2f;
	private float rangeStep = 0.3f;

	void Start () {
		animator = transform.GetComponent<Animator> ();
		this.GetNextWaypoint ();
	}
		
	void Update () {
		this.GotoPath ();
	}
	void GetNextWaypoint(){
		float oldPoint = this.range;

		foreach(Transform point in Waypoints.points){
			if (Vector3.Distance (transform.position, point.position) <= oldPoint) {
				oldPoint = Vector3.Distance (transform.position, point.position);
				this.setTarget(point,true);
			}
		}
	}
	void setTarget(Transform target, bool step = false){
		this.target = target;
		if (step) { //case true, walk more one step
			float rand = Random.Range (-this.rangeStep, this.rangeStep);
			this.Step = new Vector3 (this.target.position.x + rand, this.target.position.y + rand);
		} else {
			this.Step  = new Vector3(this.target.position.x, this.target.position.y);
		}
		animator.SetBool ("Walk",true);
	}
	void GotoPath(){
		if (target) {
			Vector3 dir = this.Step - transform.position;
			transform.Translate (dir.normalized * this.speed * Time.deltaTime, Space.World);

			float distanceToEnemy = Vector3.Distance(transform.position, this.Step);
			if (distanceToEnemy <= 0.2f) {					    
				this.target = null;
			 	animator.SetBool ("Walk", false);
				animator.SetBool ("Attack", true);
			}
		}
	}	

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position,range);
	}
}
