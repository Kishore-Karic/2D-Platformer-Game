using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private bool mustPatrol;
    private bool mustTurn;

    bool isAttacking;

    public Transform groundCheckPos;
    public LayerMask groundLayer;

    private Rigidbody2D rb2d;

    private void Start()
    {
        mustPatrol = true;
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn)
        {
           Flip();
        }

        rb2d.velocity = new Vector2(speed * Time.deltaTime, rb2d.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }

    public void CollionEnter(string colliderName, GameObject other)
    {
        if(colliderName == "DamageArea" && other.tag == "Player")
        {
            animator.SetTrigger("Attack");
            other.GetComponent<PlayerController>().TakeHit();
        }
    }
}
