using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPM_Timer : MonoBehaviour
{
    public GameObject Heartbeat;
    public Text TimerText;
    public Text Instructions;
    public InputField Input;
    float timeValue = 15f;

    bool StartTime = false;
    //void Start()
    //{
    //    StartCoroutine(waiter());
    //}

    //IEnumerator waiter()
    //{
    //    yield return new WaitForSeconds(5);
    //}

    public void StartBPM()
    {
        StartTime = true;
    }

    void Update()
    {
        if (StartTime && timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            TimerText.text = Mathf.FloorToInt(timeValue).ToString();
        }
        else if (timeValue <= 0)
        {
            TimerText.text = "0";
        }
    }
    
    public void CloseBPM()
    {
        Heartbeat.SetActive(false);
    }

    public void OnSubmitBPM()
    {
        int i = 0;

        if (string.IsNullOrEmpty(Input.text))
        { Input.text = "n/a"; }
        else if (int.TryParse(Input.text, out i))
        {
            Input.text = (i * 4).ToString();
        }
        else
        {
            Instructions.text = "Please input a valid number or nothing at all.";
        }
        //TimerText.text = "Thank you for submitting!";
        GetBPM();
        CloseBPM();
        
    }

    public string GetBPM()
    {
        Debug.Log(Input.text);
        if (string.IsNullOrEmpty(Input.text))
        {
            Input.text = "fun times";
        }
        return Input.text;
    }
}
