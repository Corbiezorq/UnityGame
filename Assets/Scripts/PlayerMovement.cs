﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 3f;
	public bool door = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckForInput ();
	}

	void CheckForInput(){
		int xDirection = 0;
		int yDirection = 0;
		if(Input.GetKey(KeyCode.UpArrow)){
			yDirection = 1;
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			xDirection = -1;
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			yDirection = -1;
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			xDirection = 1;
		}
		Vector3 direction = new Vector3 (xDirection, yDirection, 0);
		if(xDirection != 0)
		this.transform.localScale = new Vector3 (-xDirection, 1, 1);
		MovePlayer (direction);
	}

	void MovePlayer(Vector3 direction){
		this.transform.position += direction * speed * Time.deltaTime;
	}
}
