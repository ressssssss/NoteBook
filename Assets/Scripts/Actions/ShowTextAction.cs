using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextAction : Action
{
    public UnityEngine.UI.Text text = null;
    public string word;

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
        if (text != null)
        {
            Debug.Log("excute action ok");
            text.text = word;
            return true;
        }
        else
        {
            return false;
        }
    }
}
