using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    public DialogueTrigger dtrigger;

    void OnAfterSceneLoadRuntimeMethod()
    {
        dtrigger.TriggerDialogue();
        Debug.Log("Started");
    }
}
