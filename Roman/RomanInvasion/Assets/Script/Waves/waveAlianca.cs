using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveAlianca : MonoBehaviour {

	public GameObject soldier;
	public GameObject archer;
	public float rate = 5;
	private float countdown = 5;

	void Start () {
		SpawnEnemy (soldier);
	}
	void Update () {


	}

	void SpawnEnemy (GameObject soldier)
	{
		for (int i = 6; i > -6; i--) {			
			Instantiate (soldier, new Vector3 (transform.position.x, i, transform.position.z), transform.rotation);
		}
		for (int i = 6; i > -6; i--) {			
			Instantiate (soldier, new Vector3 (transform.position.x+1, i, transform.position.z), transform.rotation);
		}
		for (int i = 2; i > -6; i--) {			
			Instantiate (archer, new Vector3 (transform.position.x-2, i, transform.position.z), transform.rotation);
		}
	}
}
