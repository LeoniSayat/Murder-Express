using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivesDialogue : Interactable
{
    public DialogueTrigger dTrigger;

  protected override void Interact()
    {
        dTrigger.TriggerDialogue();
    }
}
