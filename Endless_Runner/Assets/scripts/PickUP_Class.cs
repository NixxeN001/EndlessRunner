using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUP_Class 
{
    private Vector3 intialPos;
    private float pickUp_duration;

    public float PickUp_Duration
    {
        get { return pickUp_duration; }
        set { pickUp_duration = value; }
    }

    public virtual void ActivateMethod()
    { 
    
    }

}
