using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D myrigidBody;

    float horizontalDirection;
    public float playerSpeed = 5f, jumpForce = 10;

    Vector2 playerMovement;
    Animator myAnimator;
    SpriteRenderer myRenderer;

    public bool isJumping, isDead;

    bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            MovePlayer();
            Jump();
            Attack();
        }

        if (Input.GetMouseButton(1))
            myAnimator.SetTrigger("isDead");
    }

    void MovePlayer()
    {

        horizontalDirection = Input.GetAxis("Horizontal"); 
        isRunning = Input.GetKey(KeyCode.LeftShift); 
        playerSpeed = isRunning ? 8.5f : 5f; 
         
        playerMovement = new Vector2(horizontalDirection * playerSpeed, myrigidBody.velocity.y);
        myrigidBody.velocity = playerMovement;

        if (horizontalDirection > 0)
        {
            myAnimator.SetFloat("Speed", isRunning ? 1 : 0.5f);
            myRenderer.flipX = false;

        }
        else if (horizontalDirection < 0)
        {
            myAnimator.SetFloat("Speed", isRunning ? 1 : 0.5f);
            myRenderer.flipX = true;
        }  
        else
        { 
            myAnimator.SetFloat("Speed", 0);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space)) 
            if (isJumping == false) 
                StartCoroutine(InitiateJump());  
                
        if(isJumping && Input.GetKeyDown(KeyCode.F)) 
                myAnimator.SetTrigger("isJumpAttacking"); 
         
    }


    IEnumerator InitiateJump()
    {
        isJumping = true;
        myAnimator.SetBool("isJumping", isJumping);
        myrigidBody.velocity = Vector2.up * jumpForce;

        yield return null;
    }

    void Attack()
    {
        if (!isJumping && Input.GetKey(KeyCode.F))
        {
            myAnimator.SetTrigger("isAttacking");
        }
    }

}
