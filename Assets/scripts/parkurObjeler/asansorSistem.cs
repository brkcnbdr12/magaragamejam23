using UnityEngine;

public class AsansorSistem : MonoBehaviour
{

    public float dikeyHareketHizi = 3.5f;  
    public float yukseklikSýnýrý = 6f; 

    private bool temasBool = false;

    void Update()
    {
         
        if (temasBool && transform.position.y < yukseklikSýnýrý)
        {
            float dikeyHareket = dikeyHareketHizi * Time.deltaTime;

            transform.Translate(Vector2.up * dikeyHareket);
        }
        else
        {
            float dikeyHareket = dikeyHareketHizi * Time.deltaTime;

            transform.Translate(-Vector2.up * dikeyHareket);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("sssssss");
         
        if (col.collider.CompareTag("Player"))
        {
            temasBool = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            temasBool = false;
        }
    }

}