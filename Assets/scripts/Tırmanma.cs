using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tırmanma : MonoBehaviour
{
    public float tırmanmaHızı = 3f; 

    private bool isClimbing;
    private Rigidbody2D rb;

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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 1f; 
        }
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
