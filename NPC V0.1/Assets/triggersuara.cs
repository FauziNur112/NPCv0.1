using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggersuara : MonoBehaviour
{

    public GameObject suara;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
