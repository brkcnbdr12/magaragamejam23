using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   
    public int can = 100; 

    public void AzalCan(int azalmaMiktari)
    {
        can -= azalmaMiktari;
        if (can <= 0)
        {
            // Oyuncu �ld���nde yap�lacak i�lemler burada olacak.
            Debug.Log("Oyuncu �ld�!");
        }
    }
}

