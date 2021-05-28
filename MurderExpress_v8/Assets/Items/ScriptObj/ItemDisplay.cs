using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Item/Display")]
public class ItemDisplay : Item
{
    public ToDisplay toDisplay;
    //public new GameObject displayManager;

    void Awake()
    {
        toDisplay = base.gameObject.GetComponent<ToDisplay>();
    }

    public override bool Use()
    {
        //Instantiate(displayManager);
        //GameObject thisDisplay = new GameObject(displayManager);

        toDisplay.SendToDisplay();
        
        return false;
    }
}
