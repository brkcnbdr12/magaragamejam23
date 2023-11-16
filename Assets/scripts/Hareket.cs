using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    public float hareketH�z� = 5f; 
    public float Z�platmaPower = 10f; 

    public Transform groundCheck; 
    public LayerMask groundLayer; 

    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private float groundCheck�ap = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheck�ap, groundLayer);

        
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * hareketH�z�, rb.velocity.y);

        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, Z�platmaPower);
        }
    }
}