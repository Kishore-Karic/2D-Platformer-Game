using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;

    float horizontal;
    float verticle;
    bool crouch;

    void Awake()
    {
        Debug.Log("Player Controller Awake");
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        verticle = Input.GetAxisRaw("Vertical");
        crouch = Input.GetKey(KeyCode.LeftControl);

        MoveCharacter(horizontal);
        PlayerMovementAnimation(horizontal, verticle, crouch);
    }

    void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    void PlayerMovementAnimation(float horizontal, float verticle, bool crouch)
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
        if (verticle > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        // crouch animation
        animator.SetBool("Crouch", crouch);
    }
}
