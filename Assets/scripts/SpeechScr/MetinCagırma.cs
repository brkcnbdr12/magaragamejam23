using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetinCagırma : MonoBehaviour
{
    
    public GameObject metinci;
    public string[] metinler;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        metinci = GameObject.FindWithTag("metinci");
    }
    private void Start()
    {
        
       metinci = GameObject.FindWithTag("metinKutusu");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            metinci.GetComponent<SpeechEditor>().metin = metinler[PlayerPrefs.GetInt("DialogueCount",0)];
            metinci.GetComponent<SpeechEditor>().Yazdırma();
            PlayerPrefs.SetInt("DialogueCount", PlayerPrefs.GetInt("DialogueCount", 0) + 1);
            Destroy(this.gameObject);
        }
    }
}
