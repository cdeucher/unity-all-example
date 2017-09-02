using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject pinPrefab;
	public GameObject pinPrefabMaster;

	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			SpawnPin();
		}
	}

	void SpawnPin ()
	{
		float range =  Random.Range (1f, 10f);
		if(range > 3)
		  Instantiate(pinPrefab, transform.position, transform.rotation);
		else
		  Instantiate(pinPrefabMaster, transform.position, transform.rotation);
	}

}
