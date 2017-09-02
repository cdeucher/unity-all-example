using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private GameObject Enemy;
	private Player Iam;
	private Transform target;

	public float speed = 70f;

	public int damage = 50;

	public float explosionRadius = 0f;
	public GameObject impactEffect;

	public void Seek (GameObject _target, Player _iam)
	{
		Iam = _iam;  
		Enemy  = _target;
		target = _target.transform;
	}

	// Update is called once per frame
	void Update () {

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			Debug.Log ("killlll");
			target = null;
			Enemy.SendMessage ("setLife", Iam);
			return;
		}

		//transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		//transform.LookAt(target);
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
