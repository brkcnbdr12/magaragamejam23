using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private bool isJumping;
    public int maxJump = 2;
    public int remainingJump;

    private bool isWallSliding;
    private float wallSlidingSpeed = 1f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(4f, 8f);

    private bool onRightWall;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Animator animator;

    public bool Debugger = false;
    private void Update()
    {
        if (IsWalled())
        {
            animator.SetBool("Sürükleneom", true);
           
            this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.06f, this.gameObject.GetComponent<BoxCollider2D>().size.y);
                //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 0.1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            
        }
        else
        {
            animator.SetBool("Sürükleneom", false);
            this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.12f, this.gameObject.GetComponent<BoxCollider2D>().size.y);
        }
        if(transform.localScale.x < 0 && isWallSliding)
        {
            onRightWall = false;
        }
        if (transform.localScale.x > 0 && isWallSliding)
        {
            onRightWall = true;
        }
        if (IsGrounded() == false)
        {
            animator.SetBool("AmIGrounded", false);
        }
        else animator.SetBool("AmIGrounded", true);
        if (rb.velocity.x != 0)
        {
            animator.SetBool("amIRunning", true);

        }
        else
        {
            animator.SetBool("amIRunning", false);

        }
        if (isDashing)
        {
            return;
        }

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }
    

      horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            isJumping = false;
            remainingJump = maxJump;
        }

        if (Input.GetButtonDown("Jump") )
        {
            Debugger = false;
            if (IsGrounded() ||(isJumping && remainingJump > 0) )
            {
                Invoke("ýnvoke", 0.04f);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && rb.velocity == Vector2.zero)
        {
            Debugger = false;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }
    void ýnvoke()
    {
        isJumping = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        remainingJump--;
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (!Debugger)
        {
            
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        if (!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
            
        }
    }
    
    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;

            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;
            Invoke("ýnvck", 0.1f);
            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }
    void ýnvck()
    {
        if(onRightWall && rb.velocity.x > -1 && rb.velocity.y > 1)
        {
            Debugger = true;
            rb.velocity = new Vector2(rb.velocity.x -5, rb.velocity.y);
            
        }
        if (!onRightWall && rb.velocity.x < 1 && rb.velocity.y > 1)
        {
            Debugger = true;
            rb.velocity = new Vector2(rb.velocity.x + 5, rb.velocity.y);
            
        }
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private IEnumerator Dash()
    {
        animator.SetTrigger("Dash");
        Debugger = false;//Dýþ harekete etki için.
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}