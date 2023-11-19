using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tırmanma : MonoBehaviour
{
    public float tırmanmaHızı = 3f; 

    private bool isClimbing;
    private Rigidbody2D rb;
    public Animator anim;
    public bool tırmanıyorum = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder")) 
        {
            isClimbing = true;
            rb.gravityScale = 0f; 
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Ladder"))
        {
            tırmanıyorum = true;
            anim.SetBool("Tırmanıyom", true);
        }
        if (rb.velocity.y == 0)
        {
            anim.speed = 0;
        }else
        {
            anim.speed = 1f;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        tırmanıyorum = false;
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 1f;
            Invoke("Invisible", 0.1f);
            anim.SetBool("Tırmanıyom", false);
            anim.speed = 1f;
        }
    }


    private void Invisible()
    {
        rb.gravityScale = 1;
    }

    private void Update()
    {
        if (isClimbing)
        {
            float moveInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, moveInput * tırmanmaHızı);
            rb.gravityScale = 0f; 

            
            if (moveInput == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
        }
    }
}
