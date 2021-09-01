using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    [Space]
    public float moveSpeed = 5f;
    public Animator animator;
    Vector2 movement;

    public void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        animator.SetFloat("velocityX", mx);
        animator.SetFloat("velocityY", my);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        movement = new Vector2(mx, my).normalized;
    }
}
