using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

	Animator animator;

	private Transform target;

	public  float speed = 0.3f;
	public  float range = 2f;

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
				this.target = point;

				//float rand = Random.Range (-this.rangeStep, this.rangeStep);
				//this.target = Instantiate (point, new Vector3(this.target.position.x + rand, this.target.position.y + rand), point.rotation);
				//this.target.position = new Vector3( point.position.x+rand,point.position.y+rand,point.position.z );
			}
		}
		animator.SetBool ("Walk",true);
	}
	void GotoPath(){
		if (target) {
			Vector3 dir = target.position - transform.position;
			transform.Translate (dir.normalized * this.speed * Time.deltaTime, Space.World);

			float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
			if (distanceToEnemy <= 0.1f) {	
				this.target = null;
				animator.SetBool ("Walk",false);
			}
		}
	}	

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position,range);
	}
}
