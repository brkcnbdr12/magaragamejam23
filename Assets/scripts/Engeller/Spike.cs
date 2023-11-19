using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float itmeKuvveti = 5f; 
    public int canAzalmasi = 20;
   
    bool saðdanÇarptý;
    [SerializeField] private Rigidbody2D rb;
    private PlayerMovement movement;
    private void Start()
    {
        rb = GameObject.FindWithTag("Player").gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            
            movement = collision.GetComponent<PlayerMovement>();
            if (rb != null)
            {
                movement.Debugger = true;
                Vector2 itmeYonu = (collision.transform.position - transform.position).normalized;
                if (this.CompareTag("DönenDisk")) { itmeYonu = new Vector2(itmeYonu.x - 2, itmeYonu.y); }
                
                rb.velocity = itmeYonu * itmeKuvveti;
                Invoke("inv", 0.5f);
                PlayerManager oyuncuScript = collision.GetComponent<PlayerManager>();
                if (oyuncuScript != null)
                {
                    oyuncuScript.AzalCan(canAzalmasi);
                }
            }
        }
    }
    private void inv()
    {
        movement.Debugger = false;
    }
}

