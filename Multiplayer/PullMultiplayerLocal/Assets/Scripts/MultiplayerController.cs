using UnityEngine;
using System.Collections;

public class MultiplayerController : MonoBehaviour {

	//Variaveis para pegar as classes
	public Servidor servidor;
	public Cliente cliente;

	//Variaveis para spawn e player
	public Transform spawnPoint;
	public GameObject playerPrefabVerde;
	public GameObject playerPrefabVermelho;

	private bool gui = true;

	//classes do servidor e do cliente
	[System.Serializable]
	public class Servidor{
		public string nome;
		public int maxJogadores;
		public int porta;
	}

	[System.Serializable]
	public class Cliente{
		public string nomeJogador;
		public string ip;
		public int porta;
		public string cor;
	}

	//on gui para mostrar os botoes
	void OnGUI () {
		if(gui){
			//INICIO DA BOX DE CRIAR SERVIDOR\\
			GUI.Box(new Rect(10,10,180,270), "Criar servidor");

			GUI.Label(new Rect(20,40,160,20), "Nome:");
			servidor.nome = GUI.TextField(new Rect(20,70,160,20), servidor.nome);

			GUI.Label(new Rect(20,100,160,20), "Max. Jogadores:");
			servidor.maxJogadores = int.Parse(GUI.TextField(new Rect(20,130,160,20), servidor.maxJogadores.ToString()));

			GUI.Label(new Rect(20,160,160,20), "Porta:");
			servidor.porta = int.Parse(GUI.TextField(new Rect(20,190,160,20), servidor.porta.ToString()));

			GUI.Label(new Rect(20,220,160,20), "IP: "+Network.player.ipAddress);

			if(GUI.Button(new Rect(20,250,160,20), "Criar Servidor")){
				CriarServidor();
			}
			//FIM DA BOX DE CRIAR SERVIDOR\\

			//INICIO DA BOX DE CONECTAR SERVIDOR\\
			GUI.Box(new Rect(210,10,180,270), "Conectar no servidor");
			
			GUI.Label(new Rect(220,40,160,20), "Nome do jogador:");
			cliente.nomeJogador = GUI.TextField(new Rect(220,70,160,20), cliente.nomeJogador);
			
			GUI.Label(new Rect(220,100,160,20), "IP:");
			cliente.ip = GUI.TextField(new Rect(220,130,160,20), cliente.ip);
			
			GUI.Label(new Rect(220,160,160,20), "Porta:");
			cliente.porta = int.Parse(GUI.TextField(new Rect(220,190,160,20), cliente.porta.ToString()));

			if(GUI.Button(new Rect(220,220,80,20), "Verde")){
				cliente.cor = "verde";
			}

			if(GUI.Button(new Rect(300,220,80,20), "Vermelho")){
				cliente.cor = "vermelho";
			}
			
			if(GUI.Button(new Rect(220,250,160,20), "Conectar")){
				ConectarServidor();
			}
			//FIM DA BOX DE CONECTAR SERVIDOR\\
		}
	}

	//void para criar o servidor
	private void CriarServidor(){
		Network.InitializeServer(servidor.maxJogadores, servidor.porta, true);
		gui = false;
	}

	//void para conetar
	private void ConectarServidor(){
		gui = false;

		Network.Connect(cliente.ip, cliente.porta);
	}

	//void que verifica se o player esta conectado e caso esteje spawna o jogador de acordo com a cor
	void OnConnectedToServer(){
		gui = false;

		if (cliente.cor == "vermelho") {
			Network.Instantiate(playerPrefabVermelho, spawnPoint.position, spawnPoint.rotation, 1);
		}
		if(cliente.cor == "verde"){
			Network.Instantiate(playerPrefabVerde, spawnPoint.position, spawnPoint.rotation, 1);
		}
		if(cliente.cor == ""){
			Network.Instantiate(playerPrefabVerde, spawnPoint.position, spawnPoint.rotation, 1);
		}
	}
}
