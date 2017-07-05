using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour {
    private bool pause = false;
    public GameObject player;
    public GameObject monster;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        monster = GameObject.Find("monster");
    }

    // Update is called once per frame
    void Update () {
		if(pause == true)
        {
            player.GetComponent<playerController>().setMoveOk(0);
            monster.GetComponent<MonsterController>().setMoveOk(0);
        }
        else
        {
            player.GetComponent<playerController>().setMoveOk(1);
            monster.GetComponent<MonsterController>().setMoveOk(1);
        }
	}

    public void setPause(int p)
    {
        if (p == 1)
        {
            pause = true;
        }

        else if (p == 0)
        {
            pause = false;
        }

    }

    public bool getPause()
    {
        return pause;
    }
}
