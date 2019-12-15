using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Event))]
public abstract class Trigger : MonoBehaviour
{
    public Event eve;

    public virtual void Fire(Event e)
    {

    }
}
