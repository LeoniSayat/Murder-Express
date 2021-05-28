using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTransfer : MonoBehaviour
{
    

    #region Singleton

    public static InputTransfer instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of UserInput found!!");
            return;
        }
        instance = this;
    }

    #endregion 

    [SerializeField] string UserInput;
    public GameObject inputField;
 
    [SerializeField] static bool IsCorrect = false;

 
    //public GameObject textDisplay;

    //public OnItemUsed onUsed;

    public virtual void StoreInput()
    {
       
        UserInput = inputField.GetComponent<Text>().text;
        string answer = FindObjectOfType<DialogueManager>().InputAnswer;
        IsCorrect = FindObjectOfType<DialogueManager>().checkingInput(UserInput, answer);
        
        if (IsCorrect)
        {
            TriggerAction();
        }
        //inputField.GetComponent<Text>().text = "";
        //textDisplay.GetComponent<Text>().text = "You chose " + UserInput;
    }

    public virtual void TriggerAction()
    {
        //GameObject.Find("Note_Car1Table1/BaseItem").GetComponent<OnUseGive>().onItemUsed();
        //onUsed.onItemUsed();
        //ObjectSet.SetActive(true);
        Debug.Log("Here");
    }
}

