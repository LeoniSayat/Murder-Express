 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    //add tooltip things
    //add onmousedown
    //needs flip? nah that exists already

    protected void OnMouseDown()
    {
        Interact();
    }
    
    protected virtual void Interact()
    {

    }
}
