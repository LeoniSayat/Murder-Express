using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item item;



    // Start is called before the first frame update
    public void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        
        if (wasPickedUp)
        {
            Destroy(gameObject);
            Tooltip.current.HideToolTip();
        }

        
    }
}
