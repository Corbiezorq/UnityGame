<<<<<<< HEAD:Assets/pauseController.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour {
    private bool pause = false;
    public GameObject player;
    public GameObject monster;

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("player") != null)
        {
            player = GameObject.Find("player");
        }
        if (GameObject.Find("monster") != null)
        {
            monster = GameObject.Find("monster");
        } 
    }

    // Update is called once per frame
    void Update () {
		if(pause == true)
        {
            if (GameObject.Find("player") != null)
            {
                if (player.GetComponent<playerController>())
                {
                    player.GetComponent<playerController>().setMoveOk(0);
                }
            }

            if (GameObject.Find("monster") != null)
            {
                if (monster.GetComponent<MonsterController>())
                {
                    monster.GetComponent<MonsterController>().setMoveOk(0);
                }
            }
            
        }
        else
        {
            if (GameObject.Find("player") != null)
            {
                if (player.GetComponent<playerController>())
                {
                    player.GetComponent<playerController>().setMoveOk(1);
                }
            }

            if (GameObject.Find("monster") != null)
            {
                if (monster.GetComponent<MonsterController>())
                {
                    monster.GetComponent<MonsterController>().setMoveOk(1);
                }
            }
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour {
    private bool pause = false;
    public GameObject player;
    public GameObject monster;

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("player") != null)
        {
            player = GameObject.Find("player");
        }
        if (GameObject.Find("monster") != null)
        {
            monster = GameObject.Find("monster");
        } 
    }

    // Update is called once per frame
    void Update () {
		if(pause == true)
        {
            if (GameObject.Find("player") != null)
            {
                if (player.GetComponent<playerController>())
                {
                    player.GetComponent<playerController>().setMoveOk(0);
                }
            }

            if (GameObject.Find("monster") != null)
            {
                if (monster.GetComponent<MonsterController>())
                {
                    monster.GetComponent<MonsterController>().setMoveOk(0);
                }
            }
            
        }
        else
        {
            if (GameObject.Find("player") != null)
            {
                if (player.GetComponent<playerController>())
                {
                    player.GetComponent<playerController>().setMoveOk(1);
                }
            }

            if (GameObject.Find("monster") != null)
            {
                if (monster.GetComponent<MonsterController>())
                {
                    monster.GetComponent<MonsterController>().setMoveOk(1);
                }
            }
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
>>>>>>> master:Assets/Scripts/pauseController.cs
