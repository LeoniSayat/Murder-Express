using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUseDestroy : OnItemUsed
{
    public override void onItemUsed()
    {
        Destroy(base.gameObject);
        base.dTrigger.TriggerDialogue();
    }
}
