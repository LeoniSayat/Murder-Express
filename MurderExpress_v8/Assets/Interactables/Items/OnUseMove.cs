using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUseMove : OnItemUsed
{
    public Animator animator;
    public GameObject _gameObject;
    void Awake()
    {
        animator = GameObject.Find("Map/BaseItem").GetComponent<Animator>();
    }

    public override void onItemUsed()
    {
        
        
        //Instantiate(base.gameObject, itemPos, itemRot);


        animator.enabled = true;

        StartCoroutine(ExampleCoroutine());
        
        
        if (base.dTrigger != null)
        {
            base.dTrigger.TriggerDialogue();
        }


    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        
        Vector2 itemPos = new Vector2(35.04f, 0.67f);
        Quaternion itemRot = transform.rotation;

        Instantiate(base.gameObject, itemPos, itemRot);
        _gameObject.SetActive(false);
    }
}
