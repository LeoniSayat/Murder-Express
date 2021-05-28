using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Item/Key")]
public class ItemKey : Item
{
    //Define key: an object that, when used via clicking the inventory slot, 
    //triggers something 
    //      (a barrier to SetActive(false),
    //      getting an item)
    //IF it is in a certain range
    public float radius;
    


    public string givenObjName;


    public void Awake()
    {
        //_player = GameObject.Find("Player").GetComponent<Collider2D>();
        
    }
    public override bool Use()
    {
        

        Debug.Log("I am going to use" + base.name);
        string usedName = base.name;
        //testTrigger.GetUsedName(usedName);
        bool isInRange = GameObject.Find(givenObjName).GetComponent<testTrigger>().IsInRange;
        string givenName = GameObject.Find(givenObjName).GetComponent<testTrigger>().GivenName;
        //string givenName = testTrigger.GetTargetName();
        //Debug.Log(givenName);
        //Debug.Log(usedName);
        //Debug.Log(isInRange);
        if (isInRange) 
        {
            if  (givenName == usedName)
            {
                Debug.Log("Let's gooooo");
                GameObject.Find(givenObjName).GetComponent<OnItemUsed>().onItemUsed();

                //Inventory.instance.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            Debug.Log("Not registered");
            return false;
        }
    }
}
