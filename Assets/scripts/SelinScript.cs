using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelinScript : MonoBehaviour
{
    public GameObject SelinS�rt;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SelinS�rt.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
