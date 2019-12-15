using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : Action
{
    public Transform trans = null;
    public Collider2D collider2d = null;
    public MonoBehaviour move = null;
    public Animator obj = null;
    public float time = 0;
    public Direction direction;

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
        if (obj != null && move != null && collider2d != null & trans != null)
        {
            Debug.Log("excute action ok");
            StartCoroutine(Walk());
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator Walk()
    {
        move.enabled = false;
        collider2d.enabled = false;
        Vector2 movement = Vector2.zero;
        switch (direction)
        {
            case Direction.Up:
                movement = new Vector2(0, 1);
                break;
            case Direction.Down:
                movement = new Vector2(0, -1);
                break;
            case Direction.Left:
                movement = new Vector2(-1, 0);
                break;
            case Direction.Right:
                movement = new Vector2(1, 0);
                break;
        }
        obj.SetBool("walk", true);
        obj.SetFloat("x", movement.x);
        obj.SetFloat("y", movement.y);

        float currentTime = Time.time;
        float t = 1 / time;
        Vector3 target = trans.position + new Vector3(movement.x, movement.y) * time;
        while (Time.time - currentTime < time)
        {
            trans.position = Vector3.Lerp(trans.position, target, Time.deltaTime * t);
            yield return 1;
        }
        
        obj.SetBool("walk", false);
        move.enabled = true;
        collider2d.enabled = true;
        completed = true;
        Debug.Log("Completed");
        yield break;
    }
}
