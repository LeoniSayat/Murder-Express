using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Item/Dialogue")]
public class ItemDialogue : Item
{
    public DialogueTrigger dTrigger;

    public void Awake()
    {
        dTrigger = base.gameObject.GetComponent<DialogueTrigger>();
    }

    public override bool Use()
    {
        //dTrigger = base.gameObject.GetComponent<DialogueTrigger>();
        dTrigger.TriggerDialogue();
        return false;
    }
}
