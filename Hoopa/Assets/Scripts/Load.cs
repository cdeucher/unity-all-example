using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour {

	public Transform life;

	public void Start() 
	{
		//StartCoroutine("BeepBoop");
	}

	private IEnumerator BeepBoop()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("Rank");
		// wait ONE FRAME and continue
		yield return null;

	}
	void Update () {

		life.transform.localScale = new Vector3 (life.localScale.x+(Time.deltaTime*500), life.localScale.y, life.localScale.z);
	}


}
