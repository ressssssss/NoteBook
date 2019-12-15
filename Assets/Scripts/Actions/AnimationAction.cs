using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAction : Action
{
    public Animator animator = null;
    public string state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Execute()
    {
        if (animator != null && animator.HasState(0, Animator.StringToHash(state)))
        {
            Debug.Log("excute action ok");
            animator.SetTrigger(state);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool OnAnimationCompleted()
    {
        completed = true;
        Debug.Log("Completed");
        return true;
    }
}
