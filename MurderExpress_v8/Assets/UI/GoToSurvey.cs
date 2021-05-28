using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSurvey : MonoBehaviour
{
    public void Survey()
    {
        SceneManager.LoadScene("Survey");
    }
}
