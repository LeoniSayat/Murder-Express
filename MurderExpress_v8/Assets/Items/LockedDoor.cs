using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    //[SerializeField] Collider2D thisCollider;
    [SerializeField] DialogueTrigger dTrigger;

    void Awake()
    {
        //thisCollider = gameObject.GetComponent<Collider2D>();
        dTrigger = gameObject.GetComponent<DialogueTrigger>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bumped into something");
        dTrigger.TriggerDialogue();
    }
}
