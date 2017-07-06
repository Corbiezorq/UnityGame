using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
	public bool colliding = false;
	public GameObject player;
	public GameObject LevelGenerator;
	public LevelGenerator lg;

	void Start(){
		LevelGenerator = GameObject.Find ("LevelGenerator");
		lg = LevelGenerator.GetComponent<LevelGenerator> ();
		this.player = this.gameObject;
	}
	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.gameObject.tag == "Collectable") {
			int length = this.lg.mapObjects [this.lg.GetMapIndex (this.lg.currentMap)].interactables.Length;
			for(int i = 0; i < this.lg.mapObjects[this.lg.GetMapIndex (this.lg.currentMap)].interactables.Length; i++){
				if (this.lg.mapObjects [this.lg.GetMapIndex (this.lg.currentMap)].interactables [i] != null) {
					if (this.lg.mapObjects[this.lg.GetMapIndex (this.lg.currentMap)].interactables[i].x == collider.gameObject.transform.position.x && 
						this.lg.mapObjects[this.lg.GetMapIndex (this.lg.currentMap)].interactables[i].y == collider.gameObject.transform.position.y) {
						this.lg.mapObjects[this.lg.GetMapIndex (this.lg.currentMap)].interactables[i] = null;
						break;
					}
				}
			}
			Destroy (collider.gameObject);
		}

		if (collider.gameObject.tag == "Door") {
			if (!this.player.GetComponent<PlayerMovement> ().door) {
				this.player.GetComponent<PlayerMovement> ().door = true;
				DoorData door = collider.gameObject.GetComponent<DoorData>();
				int x = door.type == 1 ? -1 : (door.type == 2? 1 : 0);
				int y = door.type == 3 ? -1 : (door.type == 4? 1 : 0);
				Vector3 vector = new Vector3 (x, y, 0);
				this.player.transform.position += vector;
				this.player.GetComponent<PlayerMovement>().ClampPosition ();
				DeleteChildren (this.LevelGenerator);
				this.lg.currentMap = door.map;
				this.lg.GenerateMap (this.lg.mapObjects[this.lg.GetMapIndex (this.lg.currentMap)]);
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

	void EnterDoor(){
	}

}
