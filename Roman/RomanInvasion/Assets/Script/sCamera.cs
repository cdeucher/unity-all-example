using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sCamera : MonoBehaviour {


	public float speed = 10.0f;
	public float minZoom = 4;
	public float maxZoom = 7;

	private float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
	private float orthoZoomSpeed = 0.1f;  

	void Start () {
	}

	void Update () {
		if (Input.touchCount == 1) {
			oneTouch (); 
		} else if (Input.touchCount > 1) {
			multTouch(); 
		} else	
		if (Input.GetMouseButton (0) || Input.GetMouseButton (1)) {	
			if (Input.GetAxis ("Mouse X") < 0) {
				transform.position -= new Vector3 (Input.GetAxis("Mouse X")* Time.deltaTime * speed, 0.0f, Input.GetAxis("Mouse Y")*Time.deltaTime * speed);
			}else
			if (Input.GetAxis ("Mouse X") > 2) {
				transform.position -= new Vector3 (Input.GetAxis("Mouse X")* Time.deltaTime * speed, 0.0f, Input.GetAxis("Mouse Y")*Time.deltaTime * speed);
			}
			/*else
			if (Input.GetAxis ("Mouse Y") < 0) {
				transform.position -= new Vector3 (0.0f, Input.GetAxis("Mouse Y")*Time.deltaTime * speed ,0.0f);
			}else
			if (Input.GetAxis ("Mouse Y") > 0) {
				transform.position -= new Vector3 (0.0f, Input.GetAxis("Mouse Y")*Time.deltaTime * speed ,0.0f);
			}*/			
		}
	}
	void oneTouch () {  
		float pointer_x = Input.GetAxis("Mouse X");
		float pointer_y = Input.GetAxis("Mouse Y");
		pointer_x = Input.touches[0].deltaPosition.x;
		pointer_y = Input.touches[0].deltaPosition.y;
		transform.position -= new Vector3 (pointer_x * Time.deltaTime * speed, pointer_y * Time.deltaTime * speed, 0.0f);	     
	}
		
	void multTouch () {
		if (Input.touchCount > 1){
			Touch touchZero = Input.touches[0];
			Touch touchOne =  Input.touches[1];

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			if (GetComponent<Camera> ().orthographic){
				GetComponent<Camera> ().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
				GetComponent<Camera> ().orthographicSize = Mathf.Max (GetComponent<Camera> ().orthographicSize, 0.1f);

				if (GetComponent<Camera> ().orthographicSize >= maxZoom)
					GetComponent<Camera> ().orthographicSize = maxZoom;
				if (GetComponent<Camera> ().orthographicSize <= minZoom)
					GetComponent<Camera> ().orthographicSize = minZoom;
			}else {
				GetComponent<Camera> ().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
				GetComponent<Camera> ().fieldOfView = Mathf.Clamp(GetComponent<Camera> ().fieldOfView, 0.1f, 179.9f);
			}
		}		
	}	
}
