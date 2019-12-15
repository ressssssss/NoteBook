using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement != Vector2.zero)
        {
            animator.SetBool("walk", true);
            animator.SetFloat("x", movement.x);
            animator.SetFloat("y", movement.y);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            player.MovePosition(player.position + movement * Time.deltaTime * 4);
        }
        else
        {
            player.MovePosition(player.position + movement * Time.deltaTime * 2);
        }
    }
}
