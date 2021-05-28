using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLeaderboard : MonoBehaviour
{
    //[SerializeField] static SheetsManager sManager;
    public Text[] UsernameDisplays = new Text[8];
    public Text[] TimeDisplays = new Text[8];
    [SerializeField] Canvas canvas;

    void Awake()
    {
        
       for (int i = 0; i < 8; i++){
            
            UsernameDisplays[i].text = "---";
            
            TimeDisplays[i].text = "---";
        }
        canvas.enabled = false;
        canvas.enabled = true;
    }

    public void Display()
    {
        //SheetsManager sManager = new SheetsManager();
        for (int i = 0; i < 8; i++){
            UsernameDisplays[i].text = SheetsManager.Usernames[i];
            TimeDisplays[i].text = SheetsManager.Times[i];
        }
    }

}
