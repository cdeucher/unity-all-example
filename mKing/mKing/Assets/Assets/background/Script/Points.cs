using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	public GameObject ProgressBar;
	private bool Instantiate = false;
	public GameObject Tower;
	public GameObject Soldiers;
	public GameObject Base;

	private bool activate = true;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clicked(){
		if (activate) {	
			activate = false;
			GameObject Bar = Instantiate (ProgressBar, new Vector3 (transform.position.x, transform.position.y + 0.6f, transform.position.z), transform.rotation);
			Bar.SendMessage ("SetBase", gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}
	public void instantiate(){
		activate = true;
		if (!Instantiate) {	
			Instantiate = true;
			Tower = Instantiate (Tower, new Vector3 (transform.position.x, transform.position.y+0.2f, transform.position.z), transform.rotation);
			Destroy ( Base );

		} else {
			Instantiate (Soldiers, new Vector3 (transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
		}
	}
}
