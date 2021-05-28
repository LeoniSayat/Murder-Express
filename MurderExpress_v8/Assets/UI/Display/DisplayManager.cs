using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    
    public GameObject Display;
    public Image image;

    void Awake()
    {
        //image = GameObject.Find("Display/Image").GetComponent<Image>();
        
    }

    public void OpenDisplay(Sprite imageDisplayed)
    {
        //imageDisplayed derived from DisplayTrigger, which will be a script added to an OnUseDisplay
        Debug.Log("Reached Display Manager");
        Display.SetActive(true);
        image.sprite = imageDisplayed;
    }

    public void CloseDisplay()
    {
        Display.SetActive(false);
        //Destroy(gameObject);
    }
}
