using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadpanel : MonoBehaviour {

	public void load(){
		SceneManager.LoadScene("Level01");
	}
}
