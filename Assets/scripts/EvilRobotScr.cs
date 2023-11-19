using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRobotScr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerManager>().AzalCan(100);
    }
}
