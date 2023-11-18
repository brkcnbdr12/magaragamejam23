using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechEditor : MonoBehaviour
{
    public TMP_Text textKoymaYER�;
    [SerializeField] private AudioSource asour;
    public float yazmaAraligi = 0.1f; 

    public IEnumerator YaziYazdir(string metin)
    {
        int index = 0;
        while (index < metin.Length)
        {
            textKoymaYER�.text += metin[index];
            index++;
            asour.Play();
            yield return new WaitForSeconds(yazmaAraligi);
        }
    }
}
