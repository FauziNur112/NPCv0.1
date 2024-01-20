using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerObjectiveOnly : MonoBehaviour
{
    public StoryManager storyManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            storyManager.SesudahStartStory(4);
        }
           
    }
}
