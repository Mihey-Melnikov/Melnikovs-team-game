using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;
    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        var movementX = Input.GetAxisRaw("Horizontal");
        Walk(movementX);
    }
    
    private void Walk(float movementX)
    {
        body.velocity = new Vector2(movementX * playerSpeed, body.velocity.y);
        sprite.flipX = (movementX < 0 || movementX == 0 && sprite.flipX);
        animator.SetBool("isRunning", Mathf.Abs(movementX) > 0.05);
    }
}
