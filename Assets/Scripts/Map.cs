using UnityEngine;

[System.Serializable]
public class Map {
	public int[] background;
	public Interactable[] interactables;
	public int x;
	public int y;

	public Map(int[] background, Interactable[] interactables, int x, int y){
		this.background = background;
		this.interactables = interactables;
		this.x = x;
		this.y = y;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
