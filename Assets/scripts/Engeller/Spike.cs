using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float itmeKuvveti = 10f; 
    public int canAzalmasi = 20; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                //çarpýþmanýn tersine kuvver uygulama
                Vector2 carptigiYon = (collision.transform.position - transform.position).normalized;

                playerRigidbody.AddForce(carptigiYon * itmeKuvveti);

                
                PlayerManager oyuncuScript = collision.GetComponent<PlayerManager>(); 
                if (oyuncuScript != null)
                {
                    oyuncuScript.AzalCan(canAzalmasi);
                }
            }
        }
    }
}

