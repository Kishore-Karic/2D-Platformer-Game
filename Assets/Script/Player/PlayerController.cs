using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private ScoreController scoreController;
    [SerializeField]
    private GameOverController gameOverController;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;

    float horizontal;
    float vertical;
    bool crouch;

    Rigidbody2D rb2d;

    bool isGrounded;
    bool isCrouching;
    bool isJumping;
    bool isDied;

    [SerializeField]
    private int lives;

    private void Start()
    {
        UIManager.Instance.AddLife(lives);
    }

    void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isDied)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Jump");
            crouch = Input.GetKey(KeyCode.LeftControl);

            MoveCharacter(horizontal, vertical);
            PlayerMovementAnimation(horizontal, vertical, crouch);
        }
    }

    public bool Alive()
    {
        return lives > 0;
    }

    public void PickUpKey()
    {
        if (!isDied)
        {
            Debug.Log("Picked Up Key");
            scoreController.IncreamentScore(1);
        }
    }

    public void TakeHit()
    {
        Debug.Log("Take Hit");
        if(lives > 0)
        {
            isDied = false;
            UIManager.Instance.RemoveLife();
            lives--;
            animator.SetTrigger("Hurt");
        }

        if(!Alive())
        {
            isDied = true;
            animator.SetBool("Death", true);
            StartCoroutine("Reload");
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Death", false);
        gameOverController.PlayerDead();
    }

    void MoveCharacter(float horizontal, float vertical)
    {
        if (!isDied)
        {
            if (!isCrouching)
            {
                Vector3 position = transform.position;
                position.x += horizontal * speed * Time.deltaTime;
                transform.position = position;
            }

            if (vertical > 0 && isGrounded && !isCrouching && !isJumping)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                Debug.Log("Jump velocity");
            }

            if (!isJumping && !isGrounded && !isCrouching)
            {
                Debug.Log("Falling");
                animator.SetBool("Fall", true);
            }

            if (isGrounded && !isCrouching)
            {
                animator.SetBool("Fall", false);
            }
        }
    }

    void PlayerMovementAnimation(float horizontal, float vertical, bool crouch)
    {
        if (!isDied)
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
            if (vertical > 0 && isGrounded && !isCrouching && !isJumping)
            {
                isJumping = true;
                Debug.Log("Jump animation");
                animator.SetTrigger("Jump");
            }

            // crouch animation
            animator.SetBool("Crouch", crouch);
            if (crouch)
            {
                isCrouching = true;
            }
            else
            {
                isCrouching = false;
            }
        }
    }

    public void SetJump(bool j)
    {
        isJumping = j;
    }

    public void SetGround(bool g)
    {
        isGrounded = g;
    }

    public void SetDeath(bool d)
    {
        isDied = true;
    }
}
