using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class PlayerBroadcast : MonoBehaviour {

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
		socket.On("move_broadcast", server_move_broadcast);
		socket.On("disconnect_broadcast", server_connect_broadcast);
	}

	void Start () { 
	}

	void Update () {
	}
	void server_move_broadcast(SocketIOEvent e){
		Debug.Log ("[SocketIO] move_broadcast : "+e);
		ClientePosition tmp = JsonUtility.FromJson<ClientePosition> (e.data.ToString());
		transform.Translate(new Vector3 (tmp.x,0,tmp.z));
	}
	void server_connect_broadcast(SocketIOEvent e){
		Debug.Log ("[SocketIO] MSG : broadcast disconnect");
		//socket.Emit ("disconnect");
		//socket.Close ();
		Destroy (gameObject);
	}
}
