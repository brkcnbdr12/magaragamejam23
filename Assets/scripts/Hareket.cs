using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    public float hareketHýzý = 5f; 
    public float ZýplatmaPower = 10f; 

    public Transform groundCheck; 
    public LayerMask groundLayer; 

    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private float groundCheckÇap = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckÇap, groundLayer);

        
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * hareketHýzý, rb.velocity.y);

        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, ZýplatmaPower);
        }
    }
}