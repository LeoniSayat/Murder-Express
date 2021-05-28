using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOptionBtns : MonoBehaviour
{
    public OnStartEnding onStart;
    public DialogueTrigger dTriggerWrong;
    public DialogueTrigger dTriggerCorrect;

    public void OnWrongGuess()
    {
        onStart.StartIntDialogue(dTriggerWrong.dialogue);
    }

    public void OnCorrectGuess()
    {
        onStart.StartIntDialogue(dTriggerCorrect.dialogue);
    }
}
