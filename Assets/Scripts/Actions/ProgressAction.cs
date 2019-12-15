using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressAction : Action
{
    public string progress;

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
        if (progress != "")
        {
            Debug.Log("excute action ok");
            Manager.getInstance().SetProgress(progress);
            return true;
        }
        else
        {
            return false;
        }
    }
}
