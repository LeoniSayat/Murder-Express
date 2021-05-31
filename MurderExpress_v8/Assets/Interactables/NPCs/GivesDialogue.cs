using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivesDialogue : Interactable
{
    public DialogueTrigger dTrigger;

  protected override void Interact()
    {
        FindObjectOfType<DialogueManager>().StopAllCoroutines();
        dTrigger.TriggerDialogue();
    }
}
