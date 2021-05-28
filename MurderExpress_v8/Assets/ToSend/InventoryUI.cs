using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        //confirms that inv slots are added to the list
        //foreach (InventorySlot slot in slots)
        //{
        //    Debug.Log(slot);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI ()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        

    }
}
