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
            GameObject x = GameObject.Find("Pause");
            x.GetComponent<pauseController>().setPause(0);

            active = false;
        }
    }

    public void setTexte(string txt)
    {
        texte = txt;
    }
}
