using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour {

	public GameObject enemy;
	public float rate = 5;
	private float countdown = 5;

	void Start () {
		SpawnEnemy (enemy);
	}
	void Update () {
		
		if (countdown <= 0f)
		{
			SpawnEnemy(enemy);
			countdown = rate;
			return;
		}
		countdown -= Time.deltaTime;


	}

	void SpawnEnemy (GameObject enemy)
	{
		for (int i = 0; i < 5; i++) {			
			Instantiate (enemy, new Vector3 (transform.position.x, i, transform.position.z), transform.rotation);
		}
		for (int i = -3; i < 2; i++) {			
			Instantiate (enemy, new Vector3 (transform.position.x-1, i, transform.position.z), transform.rotation);
		}
	}
}
