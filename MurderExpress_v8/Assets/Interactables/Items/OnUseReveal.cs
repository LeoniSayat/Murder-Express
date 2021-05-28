using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUseReveal : OnItemUsed
{
    public override void onItemUsed()
    {

        base.gameObject.SetActive(true);
     

        if (base.dTrigger != null)
        {
            base.dTrigger.TriggerDialogue();
        }


    }
}
