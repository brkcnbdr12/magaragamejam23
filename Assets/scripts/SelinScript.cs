using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelinScript : MonoBehaviour
{
    public GameObject SelinSýrt;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SelinSýrt.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
