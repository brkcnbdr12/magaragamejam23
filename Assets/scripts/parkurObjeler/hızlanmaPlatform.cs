using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hızlanmaPlatform : MonoBehaviour
{
    public float etkiGuc = 10f;
    Vector2 etkiYon; 

    void Start()
    {

        etkiYon = transform.right; 
    }

     void OnCollisionStay2D(Collision2D col )
    {
        if(col.collider.CompareTag("Player"))
        {
            Rigidbody2D oyuncuRB = col.collider.GetComponent < Rigidbody2D>();

            if (oyuncuRB != null)
            {
                oyuncuRB.AddForce(etkiYon * etkiGuc);
            }

        }
            }
}
