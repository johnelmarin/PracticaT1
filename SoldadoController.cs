using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoController : MonoBehaviour
{
    // public properties
    public float velocityX = 15;
    public float jumpForce = 70;

    // private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    // private properties
    private bool isJumping = false;

    // constants
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_SLIDE = 2;
    private const int ANIMATION_JUMP = 3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando Game Object");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(ANIMATION_IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }


        if (Input.GetKey(KeyCode.X ) && Input.GetKey(KeyCode.RightArrow) )
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y) * 5;
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }

        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y) *5;
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }


        if (Input.GetKey(KeyCode.Z))
        {
            changeAnimation(ANIMATION_SLIDE);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // salta
            changeAnimation(ANIMATION_JUMP); // saltar
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Suelo")
            isJumping = false;


    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
