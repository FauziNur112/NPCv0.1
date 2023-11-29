using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField] public Dialogue dialogue;


    private DialogueManager theDM;
    void Start()
    {
        theDM = GameObject.FindGameObjectWithTag("NPC").GetComponent<DialogueManager>();
        theDM = GetComponent<DialogueManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            theDM.ShowDialogue(dialogue);
        }
    }
}
