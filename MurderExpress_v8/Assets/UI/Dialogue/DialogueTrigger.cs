using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool IsDiary;
    [TextArea(3, 10)]
    public string[] entries;


    public bool IsUserInput;
    public Dialogue dialogue;
    public string UserAnswer;
    public string CorrectText;
    public string WrongText;
    public bool IsBarista;
    public bool IsLever;
    public bool IsRadio;
    public GameObject ObjectRevealed;
    public bool PlaysOnStart;
    public bool PlaysOnNext;
    public bool PlaysOnEnter;
    public string SoundName;

    void Awake()
    {
        if (gameObject.tag == "Barista")
        {
            IsBarista = true;
        }
    }

    public void TriggerDialogue()
    {
        string PlayCondition = null;
        if (PlaysOnStart)
        {
            PlayCondition = "OnStart";
        }
        else if (PlaysOnNext)
        {
            PlayCondition = "OnNext";
        }
        else if (PlaysOnEnter)
        {
            PlayCondition = "OnEnter";
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, IsUserInput, UserAnswer, CorrectText, WrongText, IsBarista, IsLever, ObjectRevealed, IsDiary, entries, IsRadio, SoundName, PlayCondition);
    }
}
