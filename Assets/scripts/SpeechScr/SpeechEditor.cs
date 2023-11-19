using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechEditor : MonoBehaviour
{
    public TextMeshProUGUI textKoymaYERÝ;
    [SerializeField] private AudioSource asour;
    public float yazmaAraligi = 0.1f;
    public string metin;

    public void Yazdýrma()
    {
        StartCoroutine(YaziYazdir());
    }
    public IEnumerator YaziYazdir()
    {
        Debug.Log(metin);
        int index = 0;
        while (index < metin.Length)
        {
            Debug.Log(metin);
            textKoymaYERÝ.text += metin[index];
            index++;
            asour.Play();
            yield return new WaitForSeconds(yazmaAraligi);
        }
        Invoke("Invo", 3f);
    }
    void Invo()
    {
        textKoymaYERÝ.text = "";
    }
}
