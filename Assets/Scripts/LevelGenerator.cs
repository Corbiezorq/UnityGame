using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public Map[] mapObjects;
	public IntToSprite[] backgroundMappings;
	public IntToSprite[] interactableMappings;
	public int width;
	public int height;
	// Use this for initialization
	void Start () {
		this.width = 10;
		this.height = 8;
		Map map = GetMap (0, 0);
		GenerateMap(map);
	}

	// Update is called once per frame
	void Update () {
	}
		
	Map GetMap(int x, int y){
		foreach (Map map in this.mapObjects) {
			if (map.x == x && map.y == y) {
				return map;
			}
		}
		return null;
	}

	void GenerateMaps(Map[] maps){
		foreach (Map map in maps) {
			GenerateMap(map);
		}
	}

	void GenerateMap(Map map){
		GenerateBackgrounds(map.background);
		GenerateInteractables(map.interactables);
	}

	void GenerateBackgrounds(int[] background){
		for (int i = 0; i < this.width; i++) {
			for (int j = 0; j < this.height; j++) {
				int index = (j) + (this.height * i);
				GenerateBackground (i, j, background[index]);
			}
		}
	}

	void GenerateBackground(int x, int y, int background){
		foreach (IntToSprite backgroundMapping in backgroundMappings) {
			if(backgroundMapping.index == background){
				Quaternion rotation;
				float angle = 0f;
				Vector2 position = new Vector2 (x + 0.5f, y + 1.5f);
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
				Quaternion rotation;
				float angle = 0f;
				int x = interactable.x;
				int y = interactable.y;
				Vector2 position = new Vector2 (x + 0.5f, y + 1.5f);
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
				rotation = Quaternion.Euler (0, 0, angle);
				Instantiate(InteractableMapping.sprite, position, rotation,transform);
			}
		}
	}
}
