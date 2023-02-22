using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameOverController gameOverController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FallDetector"))
        {
            playerController.SetGround(true);
            playerController.animator.SetBool("Death", true);
            StartCoroutine("Reload");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SaveScene")
        {
            PlayerPrefs.SetInt("SaveScene", SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        playerController.animator.SetBool("Death", false);
        playerController.SetDeath(true);
        gameOverController.PlayerDead();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            playerController.SetJump(false);  //isJumping = false;
            playerController.SetGround(true);  //isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            playerController.SetGround(false);  //isGrounded = false;
        }
    }
}
