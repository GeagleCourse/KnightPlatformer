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
    bool isJumping = false, isRunning = false;

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
        MovePlayer();
        Jump();


    }

    void MovePlayer()
    {

        horizontalDirection = Input.GetAxis("Horizontal");

        isRunning = Input.GetKey(KeyCode.LeftShift);
        myAnimator.SetBool("isRunning", isRunning);
        playerSpeed = isRunning ? 8.5f : 5f; 


        playerMovement = new Vector2(horizontalDirection * playerSpeed, 0f);
        myrigidBody.velocity = playerMovement;

        if (horizontalDirection > 0)
        {
            myAnimator.SetBool("isWalking", true);
            myRenderer.flipX = false;
        }
        else if (horizontalDirection < 0)
        {
            myAnimator.SetBool("isWalking", true);
            myRenderer.flipX = true;
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space)) 
            if (isJumping == false) 
                StartCoroutine(InitiateJump());  


    }


    IEnumerator InitiateJump()
    {
        isJumping = true;
        myAnimator.SetTrigger("isJumping");
        myrigidBody.velocity = new Vector2(0f, jumpForce);
        yield return new WaitForSeconds(1f);
        isJumping = false;
        myAnimator.SetBool("isJumping", isJumping);
    }

}
