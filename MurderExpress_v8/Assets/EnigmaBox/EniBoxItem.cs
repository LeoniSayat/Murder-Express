using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnigmaBox", menuName = "Inventory/Item/EnigmaBox")]
public class EniBoxItem : Item
{
    //public GameObject EniBoxDisplay;
    //public new GameObject displayManager;
    //public EniBoxMana eniBoxMana;

    public override bool Use()
    {
        //Instantiate(displayManager);
        //GameObject thisDisplay = new GameObject(displayManager);

        base.gameObject.GetComponent<OpenEniBox>().OpenBox();

        return false;
    }
}
