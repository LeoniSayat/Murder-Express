using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiaryEntry 
{

    [TextArea(3, 10)]
    public string[] entries;
}
