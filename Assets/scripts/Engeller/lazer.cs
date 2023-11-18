using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float itmeKuvveti = 1f;
    public int canAzalmasiPerSecond = 10;
    private bool LazerinIçinde = false;
    private PlayerManager playerMan;
    private bool HasarAl = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            LazerinIçinde = true;
            if (rb != null)
            {
                collision.GetComponent<PlayerMovement>().Debugger = true;
                if (this.transform.position.x < collision.transform.position.x)
                    rb.velocity = new Vector2(-rb.velocity.x * itmeKuvveti, rb.velocity.y );

                if (this.transform.position.x > collision.transform.position.x)
                    rb.velocity = new Vector2(-rb.velocity.x * itmeKuvveti, rb.velocity.y);


                playerMan = collision.GetComponent<PlayerManager>();
                
            }
        }
    }
    private void Start()
    {
        HasarVermeTimer();
    }
    void HasarVermeTimer()
    {
        HasarAl = !HasarAl;
        Invoke("HasarVermeTimer", 0.5f);
    }
    private void Update()
    {
        if (LazerinIçinde)
        {

            if (playerMan != null && HasarAl == true)
            {
                playerMan.AzalCan(canAzalmasiPerSecond);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LazerinIçinde = false;
        }
    }
}
