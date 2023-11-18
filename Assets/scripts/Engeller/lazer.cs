using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float itmeKuvveti = 5f;
    public int canAzalmasi = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (rb != null)
            {

                
                rb.velocity = new Vector2(-5 * itmeKuvveti, rb.velocity.y );

                
                Invoke("kontrol", 0.2f);
                PlayerManager oyuncuScript = collision.GetComponent<PlayerManager>();
                if (oyuncuScript != null)
                {
                    oyuncuScript.AzalCan(canAzalmasi);
                }
            }
        }
    }
}
