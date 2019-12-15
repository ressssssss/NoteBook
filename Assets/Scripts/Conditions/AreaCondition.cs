using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCondition : Condition
{
    private Collider2D collider2d = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Check()
    {
        if (collider2d && collider2d.CompareTag("Player"))
        {
            Debug.Log("check condition ok");
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collider2d = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        collider2d = null;
    }
}
