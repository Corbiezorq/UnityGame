using UnityEngine;
using System.Collections;

public class clueWindow : MonoBehaviour
{
    public Rect windowRect0 = new Rect(20, 20, 120, 40);
    public bool active = true;
    private string texte;

    void OnGUI()
    {
        if (active == true)
        {
            windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "Clue");
            windowRect0.width = 510;
            windowRect0.height = 210;
        }
    }

    void DoMyWindow(int windowID)
    {
        //texte = "Your text here";
        GUI.Label(new Rect(30, 30, 100, 20), texte);
        if (GUI.Button(new Rect(200, 90, 100, 40), "Quitter"))
        {
            //end pause
            GameObject x = GameObject.Find("monster");
            x.GetComponent<MonsterController>().setMoveOk(1);
            GameObject y = GameObject.Find("player");
            y.GetComponent<playerController>().setMoveOk(1);

            active = false;
        }
    }

    public void setTexte(string txt)
    {
        texte = txt;
    }
}
