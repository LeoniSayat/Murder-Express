using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Survey : MonoBehaviour
{
    public GameObject Alert;
    public Text alertText;
    public BPM_Timer bPM;

    string Username;
    string initialPuzzle1Time;
    string Puzzle1Hints;
    string adjPuzzle1Time;
    string initialPuzzle2Time;
    string Puzzle2Hints;
    string adjPuzzle2Time;
    string initialPuzzle3Time;
    string Puzzle3Hints;
    string adjPuzzle3Time;
    string TotalTime;
    string int_BPM;
    [SerializeField] InputField Rate;
    [SerializeField] InputField Market;
    [SerializeField] InputField Best;
    [SerializeField] InputField Improve;
    [SerializeField] InputField fin_BPM;

    private string URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSetTymutCpXreUFVYQteQpCkE2VM8pYG_fKgrUoLaHSlfiYqA/formResponse";

    void Awake()
    {
        Username = PlayerData.Username;

        initialPuzzle1Time = PlayerData.initialPuzzle1Time;
        Puzzle1Hints = PlayerData.Puzzle1Hints;
        adjPuzzle1Time = PlayerData.adjPuzzle1Time;

        initialPuzzle2Time = PlayerData.initialPuzzle2Time;
        Puzzle2Hints = PlayerData.Puzzle2Hints;
        adjPuzzle2Time = PlayerData.adjPuzzle2Time;

        initialPuzzle3Time = PlayerData.initialPuzzle3Time;
        Puzzle3Hints = PlayerData.Puzzle3Hints;
        adjPuzzle3Time = PlayerData.adjPuzzle3Time;

        TotalTime = PlayerData.TotalTime;

        int_BPM = PlayerData.Int_BPM;
        //AudioManager.instance.StopPlaying("Start");
        //AudioManager.instance.Play("End");
        
    }

    public void CloseAlert()
    {
        Alert.SetActive(false);

        
    }
    public void Send()
    {
        string[] numbers = new string[5] { "1", "2", "3", "4", "5" };
        int i = 0;

        if (string.IsNullOrEmpty(Rate.text) || string.IsNullOrEmpty(Best.text) || string.IsNullOrEmpty(Market.text) || string.IsNullOrEmpty(Improve.text))
        {
            Alert.SetActive(true);
            alertText.text = "Please answer all questions in the survey before submitting.";
            return;
        }
        else if (!Array.Exists(numbers, ele => ele == Rate.text) || !Array.Exists(numbers, ele => ele == Market.text))
        {
            Alert.SetActive(true);
            alertText.text = "Please input a number 1-5 for the rate or market-ready question.";
            return;
        }
        //else if (!int.TryParse(fin_BPM.text, out i) || !string.IsNullOrEmpty(fin_BPM.text))
        //{
        //    Alert.SetActive(true);
        //    alertText.text = "Please input a whole number for your heartbeat or leave it blank.";
        //    return;
        //}
        

        

        StartCoroutine(Post(Username, initialPuzzle1Time, Puzzle1Hints, adjPuzzle1Time, initialPuzzle2Time, Puzzle2Hints, adjPuzzle2Time, initialPuzzle3Time, Puzzle3Hints, adjPuzzle3Time, TotalTime, Rate.text, Market.text, Best.text, Improve.text, int_BPM, bPM.GetBPM()));
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Post(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16, string s17)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1238081462", s1); //entry.1238081462
        form.AddField("entry.1016186115", s2);
        form.AddField("entry.2018361194", s3);
        form.AddField("entry.1572625645", s4);
        form.AddField("entry.406227769", s5);
        form.AddField("entry.1452910543", s6);
        form.AddField("entry.538970152", s7);
        form.AddField("entry.1224950401", s8);
        form.AddField("entry.614883516", s9);
        form.AddField("entry.1490495941", s10);
        form.AddField("entry.1269903300", s11);
        form.AddField("entry.797786027", s12);
        form.AddField("entry.360120527", s13);
        form.AddField("entry.1809457395", s14);
        form.AddField("entry.963776699", s15);
        form.AddField("entry.1750702797", s16);
        form.AddField("entry.1882921700", s17);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();
    }
}