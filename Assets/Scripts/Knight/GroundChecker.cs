using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    Animator knightAnimator;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        knightAnimator = GetComponentInParent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            knightAnimator.SetBool("isJumping", false);
            knightAnimator.SetBool("isJumpAttacking", false);
            playerController.isJumping = false;
        }
    }

}
