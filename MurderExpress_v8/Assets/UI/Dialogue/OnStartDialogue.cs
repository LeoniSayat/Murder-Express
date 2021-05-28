using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnStartDialogue : MonoBehaviour
{

    public DialogueTrigger dTrigger;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject continueButton;
    public bool IsGameOver;
    public bool IsEndScene;
    [HideInInspector]
    public string currentSentence;
    Queue<string> sentences;

    //public GameObject input;
    void Start()
    {
        sentences = new Queue<string>();
        StartIntDialogue(dTrigger.dialogue);

       if (IsGameOver)
        {
            AudioManager.instance.Play("End");
        }
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



        //     dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
        StopAllCoroutines();
        dialogueText.text = string.Empty;

        if (IsGameOver || IsEndScene)
        {
            SceneManager.LoadScene("Survey");
            return;
        }
        AudioManager.instance.StopPlaying("Start");
        SceneManager.LoadScene("MainGame");
        
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
