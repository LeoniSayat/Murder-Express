using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemUsed : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameObject;
    public DialogueTrigger dTrigger;
    
    void Awake()
    {
        
    }
    public virtual void onItemUsed()
    {
        Debug.Log("Used");
    }

    
}
