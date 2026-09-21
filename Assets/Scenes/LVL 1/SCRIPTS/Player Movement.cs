using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Level1
{
public class PlayerMovement : MonoBehaviour
{
    public int coins;
    public int health = 100;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Image healthImage;

    private Rigidbody2D rb;
    private InputAction moveAction;
    private InputAction jumpAction;
    private bool isGrounded;

    private Animator animator;

    private SpriteRenderer spriteRenderer;
    public int extraJumps = 1;
    private int extraJumpsValue;
    private bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = new InputAction("Move");
        moveAction.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Negative", "<Keyboard>/leftArrow")
            .With("Positive", "<Keyboard>/d")
            .With("Positive", "<Keyboard>/rightArrow");
        moveAction.Enable();        

        jumpAction = new InputAction("Jump", binding: "<Keyboard>/space");
        jumpAction.Enable();
        animator = GetComponent<Animator>();

        extraJumpsValue = extraJumps;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
            return;
        }

        float moveInput = moveAction.ReadValue<float>();
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (jumpAction.WasPressedThisFrame() )
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
            }
        }
        SetAnimation(moveInput);

        healthImage.fillAmount = health / 100f;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
    }

    private void SetAnimation(float moveInput)
    {
        if(isGrounded)
        {
            if(moveInput  == 0)
            {
                animator.Play("Player_idle");
            }
            else
            {
                animator.Play("Player_run");
            }
        }
        else
        {
            if(rb.linearVelocity.y > 0)
            {
                animator.Play("Player_jump");
            }
            else
            {
                animator.Play("Player_fall");
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnDestroy()
    {
        moveAction?.Dispose();
        jumpAction?.Dispose();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            TakeDamage(25);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            TakeDamage(25);
        }
    }

    private void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        health = Mathf.Max(health - damage, 0);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        StartCoroutine(BlinkRed());

        if (health == 0)
        {
            Die();
        }
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;

    }
    private void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        gameover gameOverScreen = FindAnyObjectByType<gameover>(FindObjectsInactive.Include);
        if (gameOverScreen != null)
        {
            gameOverScreen.ShowGameOver();
        }

        enabled = false;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;
        Time.timeScale = 0f;
    }
}
}