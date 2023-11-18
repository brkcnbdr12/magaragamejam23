using System.Collections;
using System.Collections.Generic;
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
            // Oyuncu �ld���nde yap�lacak i�lemler burada olucak.
            Debug.Log("Oyuncu �ld�!");
        }
    }
   
}

