using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class cinematics : MonoBehaviour
{
    public PlayableDirector toLevelTwo;
    public StoryManager storyManager;
    public GameObject listing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            listing.SetActive(false);
            toLevelTwo.Play();
        }
    }
}
