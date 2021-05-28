using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnStartEnding : MonoBehaviour
{

    
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject continueButton;

    public GameObject optionsBtns;
    public DialogueTrigger dTrigger;
    public DialogueTrigger dTrigger2;

    [HideInInspector]
    public string currentSentence;
    Queue<string> sentences;

    int DialogueIndex = 0;

    //public GameObject input;
    void Start()
    {
        sentences = new Queue<string>();
        AudioManager.instance.Play("End");

        StartIntDialogue(dTrigger.dialogue);
        
        

        
        //StartCoroutine("Wait");
        //dTrigger.TriggerDialogue();
    }

    void Update()
    {
        if (dialogueText.text == currentSentence)
        {
            continueButton.SetActive(true);
        }
    }

    public void StartIntDialogue(Dialogue dialogue)
    {
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


        //if (sentences.Count == 1 && DialogueIndex == 2)
        //{
        //    optionsBtns.SetActive(true);
        //    EndDialogue();
        //    return;
        //}
        //     dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
        StopAllCoroutines();
        dialogueText.text = string.Empty;

        DialogueIndex += 1;
        Debug.Log(DialogueIndex);
        if (DialogueIndex == 1)
        {
            StartIntDialogue(dTrigger2.dialogue);
        }
        else if (DialogueIndex == 2)
        {
            optionsBtns.SetActive(true);
        }
        else if (DialogueIndex == 3)
        {
            SceneManager.LoadScene("Survey");
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

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(2);
    //}
}
