using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectivesHnadler;

public class OnTriggerPlayer : MonoBehaviour
{
    public Objectives updateObjectives;
    public ObjectivesHnadler objectivesHnadler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            updateObjectives.checkedroom++;
            updateObjectives.actSeven();
            Destroy(gameObject);
            updateObjectives.UpdateObjectives();
        }
    }
}
