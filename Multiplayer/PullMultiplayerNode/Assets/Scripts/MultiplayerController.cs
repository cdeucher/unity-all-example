using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class MultiplayerController : MonoBehaviour {

	private SocketIOComponent socket;
	private GameObject soldier;

	//Variaveis para pegar as classes
	public Cliente cliente;

	//Variaveis para spawn e player
	public Transform spawnPoint;
	public GameObject playerPrefabVerde;
	public GameObject playerPrefabVermelho;

	private bool gui = true;

	[System.Serializable]
	public class Cliente{
		public string nomeJogador;
		public string ip;
		public int porta;
		public string cor;
	}


	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", debug);
		socket.On("error", debug);
		socket.On("close", debug);

		socket.On("connect", debug);
		socket.On("msg", debug);
		socket.On("join", server_connect);
		socket.On("join_broadcast", server_connect_broadcast);
		socket.On("disconnectx", server_disconnect);

	}
    
	public void debug(SocketIOEvent e){
		Debug.Log("[SocketIO] MSG :"+e);
	}

	void Login(){
		//socket.url = "ws://"+cliente.ip+":"+cliente.porta+"/socket.io/?EIO=4&transport=websocket";
		//Debug.Log("[SocketIO] MSG : SERVER URL - "+socket.url);
		//socket.Connect ();
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["name"] = "player1";
		data["room"] = "room1";
		socket.Emit ("msg",new JSONObject(data));
		socket.Emit ("join",new JSONObject(data));

	}
	void server_connect(SocketIOEvent e){
		gui = false;
		soldier = (GameObject)Instantiate (playerPrefabVerde, spawnPoint.position,spawnPoint.rotation);
		soldier.GetComponent<Player>().setSocket(socket);
		Debug.Log("[SocketIO] connect :"+e);
	}
	void server_connect_broadcast(SocketIOEvent e){		
		Debug.Log ("[SocketIO] MSG : server_connect_broadcast");

		GameObject enemy = (GameObject)Instantiate (playerPrefabVermelho, spawnPoint.position,spawnPoint.rotation);
		enemy.GetComponent<PlayerBroadcast>().setSocket(socket);
	}
	void server_disconnect(SocketIOEvent e){
		Debug.Log ("[SocketIO] MSG : disconnect");
		Destroy (soldier);
		gui = true;
		//kill();
	}
	void kill(){
		socket.Emit ("disconnectx");
		//Destroy (soldier);
		//gui = true;
	}
	//on gui para mostrar os botoes
	void OnGUI () {
		if (gui) {
			cliente.nomeJogador = "Default";
			cliente.ip = "localhost";
			cliente.porta = 4545;

			GUI.Box (new Rect (210, 10, 180, 270), "Conectar no servidor");
			
			GUI.Label (new Rect (220, 40, 160, 20), "Nome do jogador:");
			cliente.nomeJogador = GUI.TextField (new Rect (220, 70, 160, 20), cliente.nomeJogador);
			
			GUI.Label (new Rect (220, 100, 160, 20), "IP:");
			cliente.ip = GUI.TextField (new Rect (220, 130, 160, 20), cliente.ip);
			
			GUI.Label (new Rect (220, 160, 160, 20), "Porta:");
			cliente.porta = int.Parse (GUI.TextField (new Rect (220, 190, 160, 20), cliente.porta.ToString ()));

			if (GUI.Button (new Rect (220, 250, 160, 20), "Conectar")) {
				Login ();
			}
		} else {
			if(GUI.Button(new Rect(220,250,160,80), "Logoff")){
				kill ();
			}
			if (GUI.Button (new Rect (620, 650, 60, 120), "Direita")) {
				soldier.GetComponent<Player> ().Dir ();
			}
			if (GUI.Button (new Rect (220, 650, 60, 120), "Esquerda")) {
				soldier.GetComponent<Player> ().Esq ();
			}
		}
	}


}
