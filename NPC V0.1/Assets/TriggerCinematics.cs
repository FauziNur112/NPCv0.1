using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCinematics : MonoBehaviour
{

    public TriggerDialog skenario;
    public StoryManager storyManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skenario.GetComponent<TriggerDialog>().StartDialog();
            storyManager.SesudahStartStory(storyManager.IDstory+1);
            this.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }


}
