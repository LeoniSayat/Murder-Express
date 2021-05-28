using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour
{
    public bool IsInRange;
    public new Collider2D targetCollider;
    public string GivenName;
    private string usedName;
 

    //public string GetTargetName()
    //{
        
    //    string targetName = item.base.name;
    //    return targetName
    //}
    //public void Awake()
    //{
    //    GivenName = this.GivenName;
    //}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == GameObject.Find("Player").GetComponent<Collider2D>())
        {
            Debug.Log("I was bumped into!");
            //llimit other to player
            IsInRange = true;
        }
        

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Not anymore");
        IsInRange = false;
    }
}
