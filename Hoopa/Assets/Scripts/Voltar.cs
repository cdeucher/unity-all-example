using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class Voltar : MonoBehaviour {

	public void goBack () {
		//SceneManager.LoadScene("MainLevel");
		FindObjectOfType<GameManager> ().RestartLevel ();
	}

	public void voltarOnline(){
		//((PlayGamesPlatform)Social.Active).SignOut();
		SceneManager.LoadScene("Rank");
	}

}
