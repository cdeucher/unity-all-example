using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed = 100f;
	public int dir = 1;
	public float base_speed = 100f;

	void Update ()
	{
		if (dir >= 1){
			transform.Rotate (0f, 0f, speed * Time.deltaTime);
		}else{
			var tmp = speed * Time.deltaTime;
			transform.Rotate(0f, 0f, base_speed - tmp );
		}
	}

}
