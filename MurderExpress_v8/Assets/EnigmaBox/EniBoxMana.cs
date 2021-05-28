using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EniBoxMana : MonoBehaviour
{
    public GameObject EniBox;
    public GameObject Player;
    public GameObject tHandbook;
    bool HasOpened = false;
    
    public Text Message;
    
    public Button sw1;
    public Button sw2;
    public Button sw3;
    public Button sw4;
    public Button sw5;
    public Button sw6;
    public Button sw7;
    public Button sw8;
    public Button sw9;
    public Button sw10;
    public Button sw11;
    public Button sw12;
    public Button sw13;
    public Button sw14;
    public Button sw15;
    public Button sw16;
    public Button sw17;
    public Button sw18;
    public Button sw19;
    public Button sw20;
    public Button sw21;
    public Button sw22;
    public Button sw23;
    public Button sw24;
    public Button sw25;

    public Button[,] switches;
    bool[,] fromSwitches = new bool[5,5]; //possible issue, resets the bools when close and reopen enigma box, but sprites are unchanged? i mean i could just loop reset the switch sprites
    bool[,] correctSwitches = new bool[5, 5] {
        {false, true, true, false, false },
        { false, true, false, true, false},
        { false, true, false, true, false },
        { false, true, false, true, false },
        { false, true, true, false, false } }; //insert the correct pattern here

    //bool[,] correctSwitches = new bool[5, 5] { 
    //    { false, false, false, false, false }, 
    //    { false, false, false, false, false }, 
    //    { false, false, false, false, false }, 
    //    { false, false, false, false, false }, 
    //    { false, false, false, false, false } }; //for testing purposes

    public Sprite switchOn;
    public Sprite switchOff;

    void Start()
    {
        switches = new Button[,] { 
            { sw1, sw2, sw3, sw4, sw5 }, 
            { sw6, sw7, sw8, sw9, sw10 }, 
            { sw11, sw12, sw13, sw14, sw15 }, 
            { sw16, sw17, sw18, sw19, sw20 }, 
            { sw21, sw22, sw23, sw24, sw25 } };
        
        //Debug.Log("Hello");
        
        //button.GetComponent<Image>().sprite ;
    }

    public void OpenEniBox()
    {
        EniBox.SetActive(true);
        
    }
    public void CloseEniBox()
    {
        EniBox.SetActive(false);
        Message.text = string.Empty;
    }

    void GetSwitchBool()
    {
        for (int row = 0; row < switches.GetLength(0); row++)
        {
            for (int col = 0; col < switches.GetLength(1); col++)
            {
                if (switches[row,col].GetComponent<Image>().sprite == switchOn)
                {
                    fromSwitches[row, col] = true;
                }
                else if (switches[row, col].GetComponent<Image>().sprite == switchOff)
                {
                    fromSwitches[row, col] = false;
                }
                else { Debug.Log("Wrong switch sprite"); }
            }
        }
    }

    public void CheckSwitches()
    {
        GetSwitchBool();
        bool IsCorrect = true;

        for (int row = 0; row < correctSwitches.GetLength(0); row++)
        {
            for (int col = 0; col < correctSwitches.GetLength(1); col++)
            {
                if (correctSwitches[row, col] != fromSwitches[row,col])
                {
                    IsCorrect = false;
                }
            }

        }

        if (!IsCorrect)
        {
            OnWrong();
        }
        else
        {
            OnCorrect();
        }
    }

    void OnWrong()
    {
        Message.text = "Incorrect flipped switches.";
    }
    void OnCorrect()
    {
        if (!HasOpened)
        {
            Message.text = "Correct flipped switches. The train handbook is revealed.";
            Vector2 playerPos = new Vector2(Player.GetComponent<Transform>().position.x - 1, Player.GetComponent<Transform>().position.y);
            Instantiate(tHandbook, playerPos, Quaternion.identity);
            HasOpened = true;
        }
        else
        {
            Message.text = "Correct flipped switches, but the box is already empty.";
        }
    }
    // probably make a new script to change the sprites of the buttons on flick
}
