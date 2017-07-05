using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigme2 : MonoBehaviour {

	public Rect windowRect = new Rect(20, 20, 120, 50);


	void OnGUI() {
		windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
	}

	void DoMyWindow(int windowID) {

	}

}
