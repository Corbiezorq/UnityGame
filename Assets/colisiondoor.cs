using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisiondoor : MonoBehaviour {

    public GameObject Enigme1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "player")
        {
            print("here");
            Instantiate(Enigme1);
        
        }
    }

}
