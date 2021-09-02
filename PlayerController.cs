using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public properties
    public float velocityX = 20;
    public float jumpForce = 60;

    // private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    // private properties
    private bool isJumping = false;

    private bool isIntangible = false;
    private float intangibleTime = 0f;

    // constants
    
    private const int ANIMATION_RUN = 0;
    private const int ANIMATION_JUMP = 1;
    private const int ANIMATION_SLIDE = 2;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        //sr = GetComponent<SpriteRenderer>();
        //rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(+5, rb.velocity.y);
        
        if (Input.GetKey(KeyCode.X))
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



        if (other.gameObject.name == "Enemy")
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 1);
            sr.enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger" + collider.gameObject.name);
    }

  

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}