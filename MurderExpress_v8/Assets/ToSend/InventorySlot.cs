using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        //item.gameObject.GetComponent<Spawn>().SpawnDroppedItem();
        item.SpawnDroppedItem();
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            bool usedSuccess = item.Use();
            if (item is ItemKey && usedSuccess)
            {
                Inventory.instance.Remove(item);
            }
          
        }
    }
}
