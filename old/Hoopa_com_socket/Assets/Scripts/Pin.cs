using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public GameObject hitKill;

	private bool isPinned = false;
	private int isCount   = 0;

	public float speed = 20f;
	public Rigidbody2D rb;

	void Update ()
	{
		if (!isPinned) {
			rb.MovePosition (rb.position + Vector2.up * speed * Time.deltaTime);

			if (rb.position.y > 4)
				kill ();
		}
	}

	void kill(){
		Instantiate (hitKill , transform.position, transform.rotation);
		//Destroy ( gameObject, 1f );
		Destroy ( gameObject );
	}

	void OnTriggerEnter2D (Collider2D col)
	{         
		if (col.tag == "Rotator") {
			transform.SetParent (col.transform);
			if (isCount == 0) {
				Score.PinCount++;
				isPinned = true;
			}else if (isCount >= 8){ //maximo de trocaa entre rotator
				kill ();
		    }
			isCount++;

		} else if ( col.tag == "Pin" &&  gameObject.tag == "Pin" ){ // eu bato em PIN
			kill ();					
			FindObjectOfType<GameManager> ().EndGame ();
		}else {  // eu bato em master
			kill (); 
		}
	}

}
