using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour {

	public void goBack () {
		//SceneManager.LoadScene("MainLevel");
		FindObjectOfType<GameManager> ().RestartLevel ();
	}

	public void voltarOnline(){
		SceneManager.LoadScene("Rank");
	}

}
