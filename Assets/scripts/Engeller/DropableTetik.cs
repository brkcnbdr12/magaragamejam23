using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableTetik : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
