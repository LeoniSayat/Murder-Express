using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpMenu;
    

    public void OpenHelp()
    {
        helpMenu.SetActive(true);
    }

    public void CloseHelp()
    {
        helpMenu.SetActive(false);
    }
}
