using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	public Transform follow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = Vector3.Lerp (transform.position, follow.position + new Vector3 (follow.gameObject.GetComponent<Rigidbody2D>().velocity.x/2, follow.gameObject.GetComponent<Rigidbody2D>().velocity.y/2, -10), .07f);
		if (temp.y < 0) {
			temp.y = 0;
		}
		transform.position = temp;
	}
}
