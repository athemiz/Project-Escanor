using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player_Controller : MonoBehaviour {

	private Rigidbody2D rig;
	public float speed = 10;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float hAxis = CrossPlatformInputManager.GetAxis("Horizontal");
		float vAxis = CrossPlatformInputManager.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(hAxis, vAxis, 0) * speed * Time.deltaTime;
		rig.MovePosition(transform.position + movement);
			
	}
}
