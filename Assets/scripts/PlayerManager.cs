using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Debug.Log("Oyuncu öldü!");
            Invoke("Invic",0.5f);
        }
    }
    void Invic()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        
        if (animator.speed == 0 && this.GetComponent<Týrmanma>().týrmanýyorum == false)
            animator.speed = 1;
    }
}

