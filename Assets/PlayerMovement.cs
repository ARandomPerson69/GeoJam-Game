using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody2D body;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Set player input to movement values in Vector2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement.x < 0)
        {
            
        }
    }
}
