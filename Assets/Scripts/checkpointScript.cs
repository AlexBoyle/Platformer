using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<PlayerMove> ().respawnPoint = gameObject.transform.position;
		}
	}
}
