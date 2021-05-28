using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // Will pass all the dialogue info to the manager
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
    
}
