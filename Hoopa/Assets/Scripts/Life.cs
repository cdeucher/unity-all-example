using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene("Rank");
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("OK");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("OK");
	}

}
