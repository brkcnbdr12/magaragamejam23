using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float itmeKuvveti = 5f; 
    public int canAzalmasi = 20;
   
    bool sağdanÇarptı;
    [SerializeField] private Rigidbody2D rb;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            
            if (rb != null)
            {
                
                Vector2 itmeYonu = (collision.transform.position - transform.position).normalized;
                rb.velocity = itmeYonu * itmeKuvveti;
                
                if (itmeYonu.x < 0) { sağdanÇarptı = false; }
                if (itmeYonu.x > 0) { sağdanÇarptı = true; }
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
        if(sağdanÇarptı)
        {
            if (rb.velocity.x > -5)
            {
                rb.velocity = new Vector2(100000,0);
                
            }
           
        }
        if (!sağdanÇarptı)
        {
            if (rb.velocity.x < 5)
            {
                rb.velocity = new Vector2(-100000, 0);
                
            }
        }
    }
   
}

