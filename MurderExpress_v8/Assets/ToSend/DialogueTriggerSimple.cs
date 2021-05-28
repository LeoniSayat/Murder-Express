using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerSimple : MonoBehaviour
{
    public ConfirmMana confirmMana;
    public bool IsSuspect;
    public Dialogue dialogue;

    private void Start()
    {
        confirmMana = FindObjectOfType<ConfirmMana>();
    }

    public void OnMouseDown()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        DialogueManagerSimple dialogueManagerSimple = FindObjectOfType<DialogueManagerSimple>();
        dialogueManagerSimple.StartDialogue(dialogue, IsSuspect);
        dialogueManagerSimple.dialogueTriggerSimple = this;
    }

    public void confirmManager()
    {
        if(dialogue.name == "Scarlett Brown")
        {
            SceneManager.LoadScene("GoodEnding");
        }
        else
        {
            SceneManager.LoadScene("BadEnding");
        }
    }
}
