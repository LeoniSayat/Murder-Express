using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerSimple : MonoBehaviour
{
    bool _isSuspect;
    [System.NonSerialized]
    public DialogueTriggerSimple dialogueTriggerSimple;

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject continueButton;
    public GameObject input;
    public GameObject confirm;
    
    


    [HideInInspector]
    public string currentSentence;
    [HideInInspector]
    Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        
    }

    void Update()
    {
        if (dialogueText.text == currentSentence)
        {
            continueButton.SetActive(true);
        }
    }
    public void StartDialogue(Dialogue dialogue, bool isSuspect)
    {
        _isSuspect = isSuspect;

        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {

        continueButton.SetActive(false);

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = string.Empty;
        string sentence = sentences.Dequeue();

        currentSentence = sentence;
        StartCoroutine(TypeLine(sentence));



        //     dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
        StopAllCoroutines();
        dialogueText.text = string.Empty;
        if (_isSuspect)
        {
            confirm.SetActive(true);
        }
    }

    IEnumerator TypeLine(string sentence)
    {
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.025f);
        }
    }
    public void YesButton()
    {
        dialogueTriggerSimple.confirmManager();

    }
    public void Nobutton()
    {
        confirm.SetActive(false);
    }
}
