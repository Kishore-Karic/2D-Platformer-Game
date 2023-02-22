using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jump;

    float horizontal;
    float vertical;
    bool crouch;

    Rigidbody2D rb2d;

    bool isGrounded;
    bool isCrouching;

    void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");
        crouch = Input.GetKey(KeyCode.LeftControl);

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical, crouch);
    }

    void MoveCharacter(float horizontal, float vertical)
    {
        if(!isCrouching)
        {
            Vector3 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
        }

        if(vertical > 0 && isGrounded && !isCrouching)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            Debug.Log("Jump velocity");
        }
    }

    void PlayerMovementAnimation(float horizontal, float vertical, bool crouch)
    {
        // Horizontal move animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // jump animation
        if (vertical > 0 && isGrounded && !isCrouching)
        {
            Debug.Log("Jump animation");
            animator.SetTrigger("Jump");
        }

        // crouch animation
        animator.SetBool("Crouch", crouch);
        if(crouch)
        {
            isCrouching = true;
        } else
        {
            isCrouching = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            isGrounded = false;
        }
    }
}
