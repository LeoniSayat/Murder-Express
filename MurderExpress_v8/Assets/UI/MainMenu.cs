using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject InputWindow;
    public InputField input;
    public GameObject Int_HeartbeatMana;
    public InputField int_BPM;
    public BPM_Timer bPM;

    public void Awake()
    {
        //Debug.Log("Awake");
        //audioM = FindObjectOfType<AudioManager>();
        //audioM.Play("Start");
        Scene currentScene = SceneManager.GetActiveScene();
        

        if (currentScene.name == "Menu")
        {
            AudioManager.instance.Play("Start");
            AudioManager.instance.StopPlaying("End");
            
        }
        
    }

    public void GetName()
    {
        Int_HeartbeatMana.SetActive(true);
        InputWindow.SetActive(true);
    }

    public void SubmitName()
    {
        if (string.IsNullOrEmpty(input.text))
        {
            input.placeholder.GetComponent<Text>().text = "Please input a username";
            return;
        }
        string Username = input.text;
        Debug.Log(Username);
        PlayerData.Username = Username;

        
         PlayerData.Int_BPM = bPM.GetBPM();
         Debug.Log(PlayerData.Int_BPM);

        PlayGame();
    }

    public void PlayGame()
    {
        //AudioManager.instance.StopPlaying("Start");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
