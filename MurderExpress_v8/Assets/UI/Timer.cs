using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public DiaryMana Diary;

    public float timeValue = 1800f;
    float resetTimeValue = 0f;
    public Text timerText;
    [SerializeField] bool timerActive = true;

    string initial_PTime1 = "--";
    string initial_PTime2 = "--";
    string initial_PTime3 = "--";

    string adj_PTime1 = "--";
    string adj_PTime2 = "--";
    string adj_PTime3 = "--";

    string PHints1 = "--";
    string PHints2 = "--";
    string PHints3 = "--";

    float Time1 = 600f;
    float Time2 = 600f;
    float Time3 = 600f;


    string TotalTime;
    public void subTime(float _subSeconds)
    {
        timeValue -= _subSeconds;
    }

    void Update()
    { 
        if (timerActive)
        { 
            if (timeValue > 0)
            {
                // 1800 -> 1799 -> 1798 -> 1797
                timeValue -= Time.deltaTime;
                resetTimeValue += Time.deltaTime;

                if (timeValue < 1)
                {
                    Debug.Log(timeValue);
                }
            }
            else
            {
                Debug.Log("Game Over");
                timeValue = 0f;
                OnLost();
                SceneManager.LoadScene("GameOver");

            }
            DisplayTime(timeValue);
        }
        
    }

    void OnLost()
    {
        Debug.Log($"{Time1} | {Time2} | {Time3}");
        //TotalTime = ValueToTime(Time1 + Time2 + Time3);

        AudioManager.instance.StopPlaying("Car1");
        AudioManager.instance.StopPlaying("Car2");
        AudioManager.instance.StopPlaying("Car3");

        PlayerData.DiaryEntries = Diary.DiaryContent.text;
        PlayerData.DiarySize = Diary.rT.sizeDelta;

        PlayerData.initialPuzzle1Time = initial_PTime1;
        PlayerData.initialPuzzle2Time = initial_PTime2;
        PlayerData.initialPuzzle3Time = initial_PTime3;

        PlayerData.adjPuzzle1Time = adj_PTime1;
        PlayerData.adjPuzzle2Time = adj_PTime2;
        PlayerData.adjPuzzle3Time = adj_PTime3;

        PlayerData.Puzzle1Hints = PHints1;
        PlayerData.Puzzle2Hints = PHints2;
        PlayerData.Puzzle3Hints = PHints3;

        PlayerData.TotalTime = "DNF";

        timerActive = false;
        Debug.Log("Game is over");
    }

    float FindAdjTime(float base_time, int hints)
    {
        float TimeDif = 0;
        switch (hints)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    TimeDif = 60f;
                    break;
                }
            case 2:
                {
                    TimeDif = 180f;
                    break;
                }
            case 3:
                {
                    TimeDif = 240f;
                    break;
                }
            case 4:
                {
                    TimeDif = 600f;
                    break;
                }
        }

        float returnVal = base_time + TimeDif;
        return (returnVal);
    }

    public void SaveTime1(int currentHint)
    {

        float thisTime = resetTimeValue;

        PHints1 = currentHint.ToString();
        adj_PTime1 = ValueToTime(FindAdjTime(thisTime, currentHint));
        initial_PTime1 = ValueToTime(thisTime);

        Time1 = FindAdjTime(thisTime, currentHint);

        Debug.Log(initial_PTime1);
        Debug.Log(PHints1);
        Debug.Log(adj_PTime1);
        resetTimeValue = 0f;
    }

    public void SaveTime2(int currentHint)
    {

        float thisTime = resetTimeValue;

        PHints2 = currentHint.ToString();
        adj_PTime2 = ValueToTime(FindAdjTime(thisTime, currentHint));
        initial_PTime2 = ValueToTime(thisTime);

        Time2 = FindAdjTime(thisTime, currentHint);

        Debug.Log(initial_PTime2);
        Debug.Log(PHints2);
        Debug.Log(adj_PTime2);
        resetTimeValue = 0f;
    }

    public void SaveTime3(int currentHint)
    {

        float thisTime = resetTimeValue;

        PHints3 = currentHint.ToString();
        adj_PTime3 = ValueToTime(FindAdjTime(thisTime, currentHint));
        initial_PTime3 = ValueToTime(thisTime);

        Time3 = FindAdjTime(thisTime, currentHint);

        // 7 min - 3 mins - 10min -> 10 min = time left = timeValue
        // 30mins - 10mins - (
        Debug.Log(initial_PTime3);
        Debug.Log(PHints3);
        Debug.Log(adj_PTime3);
        resetTimeValue = 0f;
    }


    string ValueToTime(float value)
    {
        float minutes = Mathf.FloorToInt(value / 60);
        float seconds = Mathf.FloorToInt(value % 60);

        string text = string.Format("{0:00}:{1:00}", minutes, seconds);
        return text;
    }


    void DisplayTime(float timetoDisplay)
    {
        if(timetoDisplay < 0)
        {
            timetoDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    

    public void StopCountdown(int currentHint)
    {
        //call the dialogue trigger and load in the next ending cutscene
        SaveTime3(currentHint);
        Debug.Log($"{Time1} | {Time2} | {Time3}");
        TotalTime = ValueToTime(Time1 + Time2 + Time3);

        AudioManager.instance.StopPlaying("Car3");
        AudioManager.instance.Play("End");
        //Debug.Log(PlayerData.DiaryEntries);
        PlayerData.DiaryEntries = Diary.DiaryContent.text;
        PlayerData.DiarySize = Diary.rT.sizeDelta;

        PlayerData.initialPuzzle1Time = initial_PTime1; 
        PlayerData.initialPuzzle2Time = initial_PTime2; 
        PlayerData.initialPuzzle3Time = initial_PTime3; 
        
        PlayerData.adjPuzzle1Time = adj_PTime1; 
        PlayerData.adjPuzzle2Time = adj_PTime2; 
        PlayerData.adjPuzzle3Time = adj_PTime3; 

        PlayerData.Puzzle1Hints = PHints1;
        PlayerData.Puzzle2Hints = PHints2;
        PlayerData.Puzzle3Hints = PHints3;

        PlayerData.TotalTime = TotalTime;

        timerActive = false;
        Debug.Log("Game is over");
    }

    

}
