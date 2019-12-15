using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform follow = null;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow != null)
        {
            Vector3 followpos = new Vector3(follow.position.x, follow.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followpos, speed);
        }
    }
}
