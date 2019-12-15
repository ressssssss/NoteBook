using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public List<Condition> conditions = new List<Condition>();
    public List<Action> actions = new List<Action>();
    private bool running = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool IsRunning()
    {
        return running;
    }

    public IEnumerator ExcuteActions()
    {
        bool excute = true;
        foreach (Condition condition in conditions)
        {
            if (!condition.Check())
            {
                excute = false;
            }
        }

        if (excute == true)
        {
            running = true;
            bool result = true;
            foreach(Action action in actions)
            {
                result = action.Execute();
                if (action.block == true)
                {
                    yield return new WaitUntil(action.IsCompleted);
                    action.Reset();
                }
                if (result == false)
                {
                    Debug.LogWarning("An action failed and interrupted the chain of Actions");
                    running = false;
                    yield break;
                }
            }
        }
        running = false;
        yield break;
    }
}
