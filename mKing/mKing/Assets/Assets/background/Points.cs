using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	public GameObject Soldiers;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clicked(){		
		Instantiate (Soldiers, new Vector3 (transform.position.x+2,transform.position.y,transform.position.z), transform.rotation);
	}
}
