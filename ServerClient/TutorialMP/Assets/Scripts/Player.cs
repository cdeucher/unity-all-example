using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade = 10;

	void Start () {
	
	}

	void Update () {
		//verifica se o network view e meu, isso proteje que outros jogadores nao controlem o meu jogador
		if(!GetComponent<NetworkView>().isMine)
			return;

		//condicoes basicas para a movimentacao
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(new Vector3(0, 0, velocidade*Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(new Vector3(-velocidade*Time.deltaTime, 0, 0));
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(new Vector3(0, 0, -velocidade*Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(new Vector3(velocidade*Time.deltaTime, 0, 0));
		}
	}
}
