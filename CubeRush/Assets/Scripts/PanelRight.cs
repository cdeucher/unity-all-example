using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRight : MonoBehaviour {
	public void right(){
		FindObjectOfType<PlayerMovement>().set_right();
	}
}
