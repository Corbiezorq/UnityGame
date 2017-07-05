using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
	public bool colliding = false;

	// Use this for initialization

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Collectable") {
//			collider.gameObject.GetComponent<Collectable>().Collect();
			Interactable interactable = collider.gameObject.GetComponent<Interactable>();
			Destroy (collider.gameObject);
		}

		if (collider.gameObject.tag == "Door") {
			if (!this.gameObject.GetComponent<PlayerMovement> ().door) {
				this.gameObject.GetComponent<PlayerMovement> ().door = true;
				DoorData door = collider.gameObject.GetComponent<DoorData>();
				this.gameObject.transform.position = new Vector3 (door.target.x, door.target.y, this.gameObject.transform.position.z);
				GameObject LevelGenerator = GameObject.Find ("LevelGenerator");
				LevelGenerator lg = LevelGenerator.GetComponent<LevelGenerator> ();
				DeleteChildren (LevelGenerator);
				lg.GenerateMap (lg.mapObjects[door.target.map]);
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.tag == "Door") {
			if (this.colliding) {
				this.gameObject.GetComponent<PlayerMovement> ().door = false;
				this.colliding = false;
			} else {
				this.colliding = true;
			}
		}
	}

	void DeleteChildren(GameObject obj){
		int childCount = obj.transform.childCount;
		for (int i = 0; i < childCount; i++) {
			Destroy (obj.transform.GetChild(i).gameObject);
		}
	}

}
