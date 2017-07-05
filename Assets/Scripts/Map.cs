using UnityEngine;

[System.Serializable]
public class Map {
	public int screenId;
	public Row[] rows;
	public Interactable[] interactables;
	public Door[] doors;
	public static int width = 10;
	public static int height = 8;

//	public Map(int[][] background, Interactable[] interactables, int x, int y){
//		this.background = background;
//		this.interactables = interactables;
//		this.x = x;
//		this.y = y;
//	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
