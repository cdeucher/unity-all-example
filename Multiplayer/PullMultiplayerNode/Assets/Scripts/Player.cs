using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Player : MonoBehaviour {

	public float velocidade = 10;
	public Transform Client;

	public SocketIOComponent socket;

	[System.Serializable]
	public class ClientePosition{
		public float x;
		public float y;
		public float z;
	}

	public void setSocket (SocketIOComponent tmp) {
		socket = tmp;
		socket.On("move", server_move);
	}

	void Start () {
	   
	}

	void Update () {
		//condicoes basicas para a movimentacao
		if(Input.GetKey(KeyCode.W)){
			//transform.Translate(new Vector3(0, 0, velocidade*Time.deltaTime));
			Move(0, 0, velocidade*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			//transform.Translate(new Vector3(-velocidade*Time.deltaTime, 0, 0));
			Move(-velocidade*Time.deltaTime, 0, 0);
		}
		if(Input.GetKey(KeyCode.S)){
			//transform.Translate(new Vector3(0, 0, -velocidade*Time.deltaTime));
			Move(0, 0, -velocidade*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			//transform.Translate(new Vector3(velocidade*Time.deltaTime, 0, 0));
			Move(velocidade*Time.deltaTime, 0, 0);
		}
	}
	public void Dir(){
		Move(velocidade*Time.deltaTime, 0, 0);
	}
	public void Esq(){
		Move(-velocidade*Time.deltaTime, 0, 0);
	}
	void Move(float x, float y, float z){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["x"] = x.ToString();
		data["z"] = z.ToString();
		socket.Emit("move", new JSONObject(data));	
		//transform.Translate(new Vector3 (x,y,z));
	}
	void server_move(SocketIOEvent e){		
		ClientePosition tmp = JsonUtility.FromJson<ClientePosition> (e.data.ToString());
		Debug.Log ("[SocketIO] MSG :" + e.data.ToString());
		transform.Translate(new Vector3 (tmp.x,0,tmp.z));
	}
}
