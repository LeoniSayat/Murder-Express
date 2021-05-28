using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    
    private int stageIndex = 1;
    public GameObject car1NPCs;
    public GameObject car1Labels;

    public GameObject car2NPCs;

    [SerializeField] DialogueManager dialogueManager;
    public int Stage = 1;

    [SerializeField] Timer timer;

    public DialogueTrigger car3dTrigger;


    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Start()
    {
        AudioManager.instance.Play("Car1");
    }

    public void CameraMove(float RoomNumber)
    {
        

        switch (RoomNumber)
        {
            case 1:
                {
                    //Debug.Log("Room 1");
                    Vector3 CameraPos = new Vector3(0f, 0f, -10f);
                    transform.position = CameraPos;
                    car1Labels.SetActive(true);
                    
                    //GameObject.Find("Car1Labels").SetActive(true);
                    //GameObject.Find("Car2Labels").SetActive(false);
                    //GameObject.Find("Car3Labels").SetActive(false);
                    break;
                }
            case 2:
                {
                    //Debug.Log("Room 2");
                    Vector3 CameraPos = new Vector3(19f, 0f, -10f);
                    transform.position = CameraPos;
                    car1Labels.SetActive(false);

                    
                    if (stageIndex == 1)
                    {
                        //destroy npcs
                        Destroy(car1NPCs);
                        stageIndex += 1;
                    }
                    if (Stage < 2)
                    {
                        Stage = 2;
                        timer.SaveTime1(dialogueManager.CurrentHint);
                        dialogueManager.CurrentHint = 0;
                        AudioManager.instance.StopPlaying("Car1");
                        AudioManager.instance.Play("Car2");
                        
                    }

                    //GameObject.Find("Car2Labels").SetActive(true);
                    //GameObject.Find("Car3Labels").SetActive(false);
                    break;
                }
            case 3:
                {
                    //Debug.Log("Room 3");
                    Vector3 CameraPos = new Vector3(38f, 0f, -10f);
                    transform.position = CameraPos;
                    //GameObject.Find("Car1Labels").SetActive(false);

                    if (stageIndex == 2)
                    {
                        Destroy(car2NPCs);
                        stageIndex += 1;
                    }
                    if (Stage < 3)
                    {
                        Stage = 3;
                        timer.SaveTime2(dialogueManager.CurrentHint);
                        dialogueManager.CurrentHint = 0;

                        car3dTrigger.TriggerDialogue();

                        AudioManager.instance.StopPlaying("Car2");
                        AudioManager.instance.Play("Car3");
                    }
                    //GameObject.Find("Car2Labels").SetActive(false);
                    //GameObject.Find("Car3Labels").SetActive(true);
                    break;
                }
            default:
                {
                    Debug.Log("Not a registered room");
                    break;
                }
        }
    }
}
