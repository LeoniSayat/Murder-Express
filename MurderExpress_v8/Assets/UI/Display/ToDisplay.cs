using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDisplay : MonoBehaviour
{
    //[SerializeField] DisplayManager displayManager;
    //public GameObject Display;
    public Sprite spriteDisplayed;
    //public GameObject Display;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void SendToDisplay()
    {
        
        Debug.Log("Reached SendToDiplay");

        FindObjectOfType<DisplayManager>().OpenDisplay(spriteDisplayed);

        Debug.Log("Sent to display manager");
        
    }
}
