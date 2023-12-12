using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCinematics : MonoBehaviour
{
    public PlayableDirector ActTwo;
    public GameObject kucing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActTwo.Play();
            Destroy(kucing);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void EndThisTimeline ()
    {
        ActTwo.Stop();
    }
}
