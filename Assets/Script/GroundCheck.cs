using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallDetector")
        {
            playerController.SetGround(true);
            playerController.animator.SetBool("Death", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            playerController.SetJump(false);  //isJumping = false;
            playerController.SetGround(true);  //isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            playerController.SetGround(false);  //isGrounded = false;
        }
    }
}
