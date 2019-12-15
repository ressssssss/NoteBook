using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTrigger : Trigger
{
    public KeyCode key = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Fire(eve);
        }
    }

    public override void Fire(Event e)
    {
        if (!e.IsRunning())
        {
            StartCoroutine(e.ExcuteActions());
        }
    }
}
