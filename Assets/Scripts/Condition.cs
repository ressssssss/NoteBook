using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    public virtual bool Check()
    {
        return true;
    }
}
