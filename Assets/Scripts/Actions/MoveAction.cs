using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    public Transform target = null;
    public Transform trans = null;
    public Animator obj = null;
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
        if (trans != null && target != null && obj != null)
        {
            Debug.Log("excute action ok");
            trans.position = target.position;
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
            obj.SetFloat("x", movement.x);
            obj.SetFloat("y", movement.y);
            return true;
        }
        else
        {
            return false;
        }
    }
}
