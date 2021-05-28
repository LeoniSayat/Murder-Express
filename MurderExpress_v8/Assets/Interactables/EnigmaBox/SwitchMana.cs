using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchMana : MonoBehaviour
{
    public Sprite switchOn;
    public Sprite switchOff;
    public Button button;

    public void OnFlick()
    {
        if (button.GetComponent<Image>().sprite == switchOn)
        {
            FlickedOff();
        }
        else { FlickedOn(); }
    }
    void FlickedOn()
    {
        button.GetComponent<Image>().sprite = switchOn;
    }
    
    void FlickedOff()
    {
        button.GetComponent<Image>().sprite = switchOff;
    }
}
