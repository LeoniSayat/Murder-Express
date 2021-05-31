using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject continueButton;
    public GameObject input;

    [HideInInspector]
    bool hasInput;
    [HideInInspector]
    public bool isCorrect;
    [HideInInspector]
    public string InputAnswer;
    
    

    [HideInInspector]
    public string currentSentence;

    
    string _correctText;
    string _wrongText;

    
    bool _isBarista;
    [HideInInspector]
    public int CurrentHint = 0;

    [HideInInspector]
    public bool _isLever;

    static Timer timer;

    GameObject player;

    bool _isDiary;
    [HideInInspector]
    public string[] _dEntry;
    public GameObject diaryMana;

    [HideInInspector]
    public GameObject _objRevealed;
    Queue<string> sentences;

    bool _isRadio;
    bool CorrectLever = false;
    bool CorrectRadio = false;

    string _soundName;
    string _playCondition;

    //public string CurrentSentence;
    void Awake()
    {
        
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        player = GameObject.Find("Player");
        //diaryMana = FindObjectOfType<DiaryMana>();
    }

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

    public void StartDialogue(Dialogue dialogue, bool isUserInput, string userAnswer, string correctText, string wrongText, bool isBarista, bool isLever, GameObject objRevealed, bool isDiary, string[] dEntry, bool isRadio, string soundName, string playCondition)
    {
        dialogueBox.SetActive(true);
        input.SetActive(false);
        nameText.text = dialogue.name;
        player.GetComponent<PlayerMovement>().CanMove = false;
        
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        hasInput = isUserInput;
        InputAnswer = userAnswer;
        _correctText = correctText;
        _wrongText = wrongText;
        _isBarista = isBarista;
        _isLever = isLever;
        _isRadio = isRadio;
        _objRevealed = objRevealed;
        _isDiary = isDiary;
        _dEntry = dEntry;
        _soundName = soundName;
        _playCondition = playCondition;

        if (!string.IsNullOrEmpty(soundName) && _playCondition == "OnStart")
        {
            AudioManager.instance.Play(soundName);
        }
        DisplayNextSentence();
    }

    
    public void SkipWrite()
    {
        StopAllCoroutines();
        dialogueText.text = currentSentence;
    }
    IEnumerator TypeLine(string sentence)
    {
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            
            yield return new WaitForSeconds(0.025f);
        }
    }

    public void SendValueToTimer(float subSeconds)
    {
        timer.subTime(subSeconds);
    }

    public void DetectHintUsed()
    {
        if (_isBarista)
        {


            switch (sentences.Count)
            {
                case 7:
                    //Debug.Log("Giving first hint");
                    if (CurrentHint < 1)
                    {
                        CurrentHint = 1;
                        SendValueToTimer(60f);
                    }
                    
                    break;
                case 5:
                    //Debug.Log("Giving second hint");
                    if (CurrentHint < 2)
                    {
                        CurrentHint = 2;
                        SendValueToTimer(120f);
                    }
                    break;
                case 3:
                    //Debug.Log("Giving third hint");
                    if (CurrentHint < 3)
                    {
                        CurrentHint = 3;
                        SendValueToTimer(180f);
                    }
                    break;
                case 1:
                    //Debug.Log("Giving answer");
                    if (CurrentHint < 4)
                    {
                        CurrentHint = 4;
                        SendValueToTimer(240f);
                    }
                    break;

                default:
                    //Debug.Log("Not giving a hint");

                    break;
            }
            //Debug.Log(CurrentHint);
        }
    }

    public void DisplayNextSentence()
    {

        continueButton.SetActive(false);

        DetectHintUsed();

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else if (sentences.Count == 1 && hasInput == true)
        {
            //Debug.Log("Need to get input");
            input.SetActive(true);
        }
        dialogueText.text = string.Empty;
        string sentence = sentences.Dequeue();

        currentSentence = sentence;
        StartCoroutine(TypeLine(sentence));

        if (!string.IsNullOrEmpty(_soundName) && _playCondition == "OnNext")
        {
            AudioManager.instance.Play(_soundName);
        } 
        //add diary entry via diary manager
        if (_isDiary)
        {
            diaryMana.GetComponent<DiaryMana>().AddEntry(_dEntry);
            
        }
        
        
 //     dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        //Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
        StopAllCoroutines();
        dialogueText.text = string.Empty;
        player.GetComponent<PlayerMovement>().CanMove = true;

        diaryMana.GetComponent<DiaryMana>().EntryIndex = 0;
        //Debug.Log($"{CorrectLever}    {CorrectRadio}");
        if (CorrectLever && CorrectRadio)
        {
            timer.StopCountdown(CurrentHint);
            // AudioManager.instance.StopPlaying("Car3");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    }

    public bool checkingInput(string Input, string answer)
    {
        //answer = DialogueTrigger.UserAnswer;
        // all the given answers are ToLower!
        //Debug.Log(Input);
        if (!string.IsNullOrEmpty(_soundName) && _playCondition == "OnEnter")
        {
            AudioManager.instance.Play(_soundName);
        }

        if (!Input.ToLower().Contains("right") && !Input.ToLower().Contains("left"))
        {
            if (_isLever)
            {
                dialogueText.text = "Please input a direction (left or right)";
                return false;
            }
        }
        
        if (Input.ToLower().Contains(answer))
        {
            Debug.Log("correct answer");

            if (_isLever)
            {
                CorrectLever = true;
            }
            else if (_isRadio)
            {
                CorrectRadio = true;
            }

            
            input.SetActive(false);
            dialogueText.text = _correctText;
            isCorrect = true;
            if (_objRevealed != null)
            {
                _objRevealed.SetActive(true);
            }
            return true;
        }
        else
        {
            if (_isLever)
            {
                //Debug.Log("wrong lever");
                input.SetActive(false);
                dialogueText.text = _wrongText;
                isCorrect = false;
                timer.subTime(600f);
                CorrectLever = true;
                return true;
            }
            //Debug.Log("wrong answer");
            input.SetActive(false);
            dialogueText.text = _wrongText;
            isCorrect = false;
            return false;
        }
        
    }
}
