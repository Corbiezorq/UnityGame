using UnityEngine;
using System.Collections;

public class Enigme1 : MonoBehaviour
{
    public Rect windowRect0 = new Rect(20, 20, 120, 50);
    public string codex = "";
    public bool active = true, responsefalse, responseok;
    public Texture2D noTexture, okTexture;

    void OnGUI()
    {
        if (active == true)
        {
            windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "Enigme 1");
            windowRect0.width = 510;
            windowRect0.height = 210;
        }
    }

    void DoMyWindow(int windowID)
    {
        int i = 0;
        int k = 10;
        string label;
        string texte = "Entrer le code";
        
        //display image 
        if (responsefalse)
        {
            GUI.DrawTexture(new Rect(350, 50, 80, 80), noTexture, ScaleMode.ScaleAndCrop);
        }
        if (responseok)
        {
            GUI.DrawTexture(new Rect(350, 50, 80, 80), okTexture, ScaleMode.ScaleAndCrop);
            active = false;
            //end pause
            GameObject x = GameObject.Find("monster");
            x.GetComponent<MonsterController>().setMoveOk(1);
            GameObject y = GameObject.Find("player");
            y.GetComponent<playerController>().setMoveOk(1);
        }


        GUI.Label(new Rect(30, 30, 100, 20), texte);
        GUI.Label(new Rect(30, 60, 100, 20), "code : "+codex);
        if (GUI.Button(new Rect(30, 90, 100, 40), "Valider"))
        {
            if(codex == "1234")
            {
                print("response ok");
                responseok = true;
                responsefalse = false;
            }
            else
            {
                codex = "";
                responsefalse = true;

                print("response false");
            }
        }
        if (GUI.Button(new Rect(160, 90, 100, 40), "Quitter"))
        {
            active = false;
            //end pause
            GameObject x = GameObject.Find("monster");
            x.GetComponent<MonsterController>().setMoveOk(1);
            GameObject y = GameObject.Find("player");
            y.GetComponent<playerController>().setMoveOk(1);
        }

        for (i = 0; i < 10; i++)
        {
            label = i.ToString();
            if (GUI.Button(new Rect(k, 160, 40, 40), label))
            {
                codex += i.ToString();
                print(codex);
            }
            k += 50;
        }
    }

}