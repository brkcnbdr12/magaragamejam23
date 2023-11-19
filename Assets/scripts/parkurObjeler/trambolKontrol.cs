using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trambolKontrol : MonoBehaviour
{
    public float etkiGucu = 10f;
    private Animator animator;
    [SerializeField] private PlayerMovement hareket;

    private void Start()
    {
        animator = GetComponent<Animator>();
        hareket = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.collider.CompareTag("Player"))
        {
            Rigidbody2D playerRB = col.collider.GetComponent<Rigidbody2D>();
            hareket.enabled = false;

            Vector2 carpismaNormali = col.GetContact(0).normal;

            hareket.Debugger = true;
            if (playerRB != null)
            {
                Vector2 etkiVektoru = -carpismaNormali * etkiGucu;
                Invoke("Invokee", 0.5f);
                playerRB.velocity = etkiVektoru;
                Debug.Log("algýladm");
            }
        }
    }
    void Invokee()
    {
        hareket.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("indir", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("ýnvý",0.5f);
    }
    void ýnvý()
    {
        animator.SetBool("indir", false);
    }
}
