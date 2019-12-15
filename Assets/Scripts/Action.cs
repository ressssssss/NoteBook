using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }


    public bool block;
    protected bool completed = false;

    public virtual bool Execute()
    {
        return true;
    }
    
    public bool IsCompleted()
    {
        return completed;
    }

    public void Reset()
    {
        completed = false;
    }
}
