using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        Debug.Log("Player Controller Awake");
    }

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;

        if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        } else if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        float jump = Input.GetAxisRaw("Vertical");
        if(jump > 0)
        {
            animator.SetBool("Jump", true);
        } else
        {
            animator.SetBool("Jump", false);
        }

        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", crouch);
    }
}
