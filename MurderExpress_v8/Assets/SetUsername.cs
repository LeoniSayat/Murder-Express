using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUsername : MonoBehaviour
{
    
    void Start()
    {
        if (PlayerData.Username != null)
        {
            gameObject.GetComponent<TextMesh>().text = PlayerData.Username;
        }
        
    }

    
}
