using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerHantu : MonoBehaviour
{
    public GameObject Hantu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Hantu.SetActive(true);
            Hantu.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
  
}
