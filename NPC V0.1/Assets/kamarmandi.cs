using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamarmandi : MonoBehaviour
{

    public GameObject suara;
    public GameObject dialogtolevelthrees;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            suara.SetActive(true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            dialogtolevelthrees.SetActive(true);
        }
    }
}
