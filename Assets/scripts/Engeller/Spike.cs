using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float itmeKuvveti = 5f; 
    public int canAzalmasi = 20;
   
    bool saðdanÇarptý;
    [SerializeField] private Rigidbody2D rb;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            
            if (rb != null)
            {
                
                Vector2 itmeYonu = (collision.transform.position - transform.position).normalized;
                rb.velocity = itmeYonu * itmeKuvveti;
                
                if (itmeYonu.x < 0) { saðdanÇarptý = false; }
                if (itmeYonu.x > 0) { saðdanÇarptý = true; }
                Invoke("kontrol", 0.2f);
                PlayerManager oyuncuScript = collision.GetComponent<PlayerManager>();
                if (oyuncuScript != null)
                {
                    oyuncuScript.AzalCan(canAzalmasi);
                }
            }
        }
    }
    void kontrol()
    {
        if(saðdanÇarptý)
        {
            if (rb.velocity.x > -5)
            {
                rb.velocity = new Vector2(100000,0);
                
            }
           
        }
        if (!saðdanÇarptý)
        {
            if (rb.velocity.x < 5)
            {
                rb.velocity = new Vector2(-100000, 0);
                
            }
        }
    }
   
}

