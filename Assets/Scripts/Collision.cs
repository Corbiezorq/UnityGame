using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	// Use this for initialization

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Collectable") {
//			collider.gameObject.GetComponent<Collectable>().Collect();
			Destroy (collider.gameObject);
		}
	}
}
