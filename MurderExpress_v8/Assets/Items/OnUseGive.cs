using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUseGive : OnItemUsed
{

    private Vector2 playerPos;

    public override void onItemUsed()
    {
        
         Transform player = GameObject.Find("Player").transform;
         Vector2 playerPos = new Vector2(player.position.x - 1, player.position.y);
        
        
        Instantiate(base.gameObject, playerPos, Quaternion.identity);
        
        if (base.dTrigger != null)
        {
            base.dTrigger.TriggerDialogue();
        }


    }
}
