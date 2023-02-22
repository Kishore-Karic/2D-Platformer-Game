using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FallDetector"))
        {
            playerController.SetGround(true);
            playerController.animator.SetBool("Death", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.SetJump(false);  //isJumping = false;
            playerController.SetGround(true);  //isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerController.SetGround(false);  //isGrounded = false;
        }
    }
}
