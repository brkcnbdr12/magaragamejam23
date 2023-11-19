using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Animator animator;
    public int can = 100;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AzalCan(int azalmaMiktari)
    {
        can -= azalmaMiktari;
        animator.SetTrigger("GetDamage");
        if (can <= 0)
        {
            animator.SetBool("IAmDeath",true);
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Debug.Log("Oyuncu �ld�!");
        }
    }

    private void Update()
    {
        if (animator.speed == 0 && this.GetComponent<T�rmanma>().t�rman�yorum == false)
            animator.speed = 1;
    }
}

