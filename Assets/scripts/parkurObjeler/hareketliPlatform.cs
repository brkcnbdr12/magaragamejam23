using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareketliPlatform : MonoBehaviour
{
    public float mesafe;
    
    public float platH�z;
    private Vector2 startPosition;

    private bool sagaGidis = true;

    void Start()
    {

        startPosition = transform.position;
    }


    void Update()
    {
       

        if (sagaGidis)
        {
            transform.Translate(Vector2.right * platH�z * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.left * platH�z * Time.deltaTime);

        }

        if(Vector2.Distance(startPosition, transform.position) >= mesafe)
        {
            sagaGidis = !sagaGidis;  

        }
        
    }
}
