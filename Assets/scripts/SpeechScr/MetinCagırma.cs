using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetinCagırma : MonoBehaviour
{
    public int DialogueCount = 0;
    [SerializeField] private SpeechEditor metinci;
    public string[] metinler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            metinci.YaziYazdir(metinler[DialogueCount]);
            DialogueCount++;
        }
    }
}
