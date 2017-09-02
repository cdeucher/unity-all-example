using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLeft : MonoBehaviour {
	public void left(){
		FindObjectOfType<PlayerMovement>().set_left();
	}
}
