using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject gameObject;

    private Transform player;

    //private void Update()
    //{
    //    player = GameObject.Find("Player").transform;
    //}

    public virtual void SpawnDroppedItem()
    {
        player = GameObject.Find("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x - 1, player.position.y);
        Instantiate(gameObject, playerPos, Quaternion.identity);
    }

    public virtual bool Use()
    {
        //Use the item
        //something might happen

        Debug.Log("Using" + name);
        Debug.Log(gameObject);
        return false;
    }
}
