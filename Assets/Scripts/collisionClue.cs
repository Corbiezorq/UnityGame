using UnityEngine;

public class collisionClue : MonoBehaviour {

    public GameObject ClueWindow;
    public string texte;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player")
        {
            //start pause
            GameObject x = GameObject.Find("monster");
            x.GetComponent<MonsterController>().setMoveOk(0);
            col.gameObject.GetComponent<playerController>().setMoveOk(0);

            GameObject y = Instantiate(ClueWindow);
            y.GetComponent<clueWindow>().setTexte(texte);
        }
    }
}
