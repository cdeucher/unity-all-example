using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

	public Transform bar;
	public float range = 0.3f;
	public GameObject Base;



	void Start () {
		
	}
	void SetBase(GameObject Base){
		this.Base = Base;
	}

	void Update () {
		bar.transform.localScale = new Vector3 (bar.localScale.x-(Time.deltaTime*range), bar.localScale.y, bar.localScale.z);
		if (bar.localScale.x <= 0) {
			this.Base.SendMessage ("instantiate", gameObject, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
}
