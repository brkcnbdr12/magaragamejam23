using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class akımKontrol : MonoBehaviour
{
    public LayerMask layerOyuncu; 
    public float maxMesafe = 5f; 
    public float akımGucu = 5f;
    [SerializeField] private PlayerMovement hareket;
    [SerializeField] private Vector2 rcYonu = Vector2.right;
    void Update()
    {
        
        Vector2 baslangıc = transform.position;
        
        

        
        RaycastHit2D hit = Physics2D.Raycast(baslangıc, rcYonu, maxMesafe, layerOyuncu);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Rigidbody2D oyuncuRB = hit.collider.GetComponent<Rigidbody2D>();

            
            if (oyuncuRB != null)
            {
                
                float mesafeOrani = 1f - Mathf.Clamp01(hit.distance / maxMesafe); 
                float akimArtis = akımGucu * mesafeOrani;

                hareket.Debugger = true;
                oyuncuRB.AddForce(rcYonu * akimArtis);
            }
        }
    }


}
