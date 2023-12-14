using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCinematics : MonoBehaviour
{
    public PlayableDirector Act;
    public GameObject skenariosatu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            /*Act.Play();*/
            skenariosatu.GetComponent<TriggerDialog>().StartDialog(); 
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void EndThisTimeline ()
    {
        Act.Stop();
    }
}
