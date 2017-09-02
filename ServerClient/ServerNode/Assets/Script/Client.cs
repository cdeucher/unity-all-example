using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Client : MonoBehaviour {

	private SocketIOComponent socket;

	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", msg);
		socket.On("error", msg);
		socket.On("close", msg);

		socket.On("connect", msg);
		socket.On("boop", boop);
		socket.On("msg", msg);


	}
	public void go(){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["name"] = "xx";
		data["position"] = "12";
		socket.Emit("msg", new JSONObject(data));	
	}
	public void SendMsg(Dictionary<string, string> data){
		//Dictionary<string, string> data = new Dictionary<string, string>();
		//data["name"] = "xx";
		//data["position"] = "12";

		socket.Emit("msg", new JSONObject(data));

	}
	public void beep(){
		socket.Emit ("beep");
	}
	public void boop(SocketIOEvent e){
		Debug.Log("[boop] MSG :"+e);
	}
	public void msg(SocketIOEvent e){
		Debug.Log("[SocketIO] MSG :"+e);
	}
}
