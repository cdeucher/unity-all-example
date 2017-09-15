using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	public GameObject crossfade;

	void Start () {
		Instantiate (crossfade);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
