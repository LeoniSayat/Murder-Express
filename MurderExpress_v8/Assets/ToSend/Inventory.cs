using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found!!");
                return;
        }
        instance = this;
    }

    #endregion 

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 6;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null) ;
        {
            onItemChangedCallback.Invoke();
        }
        //Debug.Log(items[0]);
        return true;
    }

    public void Remove(Item item)
    {
        //Item.gameObject.GetComponent<Spawn>().SpawnDroppedItem();
        items.Remove(item);
        if (onItemChangedCallback != null) ;
        {
            onItemChangedCallback.Invoke();
        }
    }


    //void Start()
    //{
    //    inventory = Inventory.instance;
    //    inventory.onItemChangedCallback += UpdateUI;
    //}

    //void Update()
    //{
        
    //}

    //void UpdateUI()
    //{
    //    Debug.Log("UPDATING UI");
    //}
}
