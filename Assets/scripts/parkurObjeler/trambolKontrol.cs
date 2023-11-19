using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trambolKontrol : MonoBehaviour
{
    public float etkiGucu = 10f;  

    void OnCollisionEnter2D(Collision2D col)
    {
     
        if (col.collider.CompareTag("Player"))
        {
            Rigidbody2D playerRB = col.collider.GetComponent<Rigidbody2D>();

             
            Vector2 carpismaNormali = col.GetContact(0).normal;

            
            if (playerRB != null)
            {
                Vector2 etkiVektoru = -carpismaNormali * etkiGucu;

                playerRB.velocity = etkiVektoru;
            }
        }
    }
}
