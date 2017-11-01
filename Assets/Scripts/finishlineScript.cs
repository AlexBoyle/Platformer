using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finishlineScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			int next = SceneManager.GetActiveScene ().buildIndex + 1;
			Debug.Log (next);
			if(SceneManager.sceneCount >= next){
				SceneManager.LoadScene (next);
			}
		}
	}
}