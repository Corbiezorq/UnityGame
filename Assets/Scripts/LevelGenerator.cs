using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LevelGenerator : MonoBehaviour {
	public Map[] mapObjects;
	public IntToSprite[] backgroundMappings;
	public IntToSprite[] interactableMappings;
	public int width;
	public int height;
	public int currentMap;

	void Start () {
		this.width = 10;
		this.height = 8;
		this.mapObjects = HandleTextFile.ReadJson ("maps.json");
		this.currentMap = 0;
		GenerateMap(this.mapObjects[GetMapIndex(currentMap)]);
	}
		
	int GetMapIndex(int id){
		for (int i = 0; i < this.mapObjects.Length; i++) {
			if (mapObjects[i].screenId == id) {
				return i;
			}
		}
		return -1;
	}

	public void GenerateMap(Map map){
		GenerateBackgrounds(map.rows);
		GenerateInteractables(map.interactables);
		GenerateDoors(map.doors);
	}

	void GenerateBackgrounds(Row[] background){
		for (int i = 0; i < this.width; i++) {
			for (int j = 0; j < this.height; j++) {
				GenerateBackground (i, j, background[j].row[i]);
			}
		}
	}

	void GenerateBackground(int x, int y, int cell){
		foreach (IntToSprite backgroundMapping in backgroundMappings) {
			if(backgroundMapping.index == cell){
				Quaternion rotation;
				float angle = 0f;
				Vector2 position = new Vector2 (x, y);
				rotation = Quaternion.Euler (0, 0, angle);
				Instantiate(backgroundMapping.sprite, position, rotation,transform);
			}
		}
	}

	void GenerateInteractables(Interactable[] interactables){
		for (int i = 0; i < interactables.Length; i++) {
			GenerateInteractable (interactables[i]);
		}
	}

	void GenerateInteractable(Interactable interactable){
		foreach (IntToSprite InteractableMapping in interactableMappings) {
			if(InteractableMapping.index == interactable.obj){
				float angle = 0f;
				int x = interactable.x;
				int y = interactable.y;
				Vector2 position = new Vector2 (x, y);
				if (InteractableMapping.sprite.name == "Door") {
					if (x == 0) {
						angle = 90f;
					} else if (x == this.width - 1) {
						angle = -90f;
					} else if (y == 0) {
						angle = 180f;
					} else if (y == this.height - 1) {
						angle = 0f;
					} 
				}
				Quaternion rotation = Quaternion.Euler (0, 0, angle);
				Instantiate(InteractableMapping.sprite, position, rotation,transform);
			}
		}
	}

	void GenerateDoors(Door[] doors){
		for (int i = 0; i < doors.Length; i++) {
			GenerateDoor (doors[i]);
		}
	}

	void GenerateDoor(Door door){
		foreach (IntToSprite InteractableMapping in interactableMappings) {
			if(InteractableMapping.index == door.obj){
				float angle = 0f;
				int x = door.x;
				int y = door.y;
				Vector2 position = new Vector2 (x, y);
				if (InteractableMapping.sprite.name == "Door") {
					if (x == 0) {
						angle = 90f;
					} else if (x == this.width - 1) {
						angle = -90f;
					} else if (y == 0) {
						angle = 180f;
					} else if (y == this.height - 1) {
						angle = 0f;
					} 
				}
				Quaternion rotation = Quaternion.Euler (0, 0, angle);
				DoorData doorScript = (InteractableMapping.sprite).GetComponent<DoorData>();
				doorScript.x = door.x;
				doorScript.y = door.y;
				doorScript.target = door.target;
				Instantiate(InteractableMapping.sprite, position, rotation,transform);
			}
		}
	}
}
