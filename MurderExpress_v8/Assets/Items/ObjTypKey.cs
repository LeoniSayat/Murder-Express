using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTypeKey : Item
{
    public float radius;
    public GameObject targetObject;

    public override bool Use()
    {
        //this is what will happen if the obj is a key and it is used
        //checks for a target object within a certain radius,
        //if the target is within the radius, it is used (derive child scripts from this point, create and call a protected virtual void method)
        return false;
    }
}
