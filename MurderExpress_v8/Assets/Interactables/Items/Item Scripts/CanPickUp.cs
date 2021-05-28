using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPickUp : Interactable
{
    public ItemPickup itemPickup;

    protected override void Interact()
    { //Debug.Log("Circle clicked!");
        itemPickup.PickUp();
    }
        
    
}
