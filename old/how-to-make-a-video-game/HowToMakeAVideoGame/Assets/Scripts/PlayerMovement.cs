using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
	public bool xleft;
	public bool xright;
	// We marked this as "Fixed"Update because we
	// are using it to mess with physics.
	void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))	// If the player is pressing the "d" key
		{
			right();
		}

		if (Input.GetKey("a"))  // If the player is pressing the "a" key
		{
			left();
		}

		if(rb.position.y < 0)
			SceneManager.LoadScene("Load");
	}
	public void right(){
		rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
	}
	public void left(){
		rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
	}
	public void set_right(){
		right ();
	}
	public void set_left(){
		left ();
	}
}
