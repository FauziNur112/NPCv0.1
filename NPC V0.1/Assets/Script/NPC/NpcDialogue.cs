using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;
    private SpriteRenderer speechBubbleRenderer;


    public dialogueUI dialogNPC;

    void Start()
    {
        speechBubbleRenderer = GetComponent<SpriteRenderer>();
        speechBubbleRenderer.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" ) 
        { 
            speechBubbleRenderer.enabled=true;
            player = collision.gameObject.GetComponent<Transform>();

            if (player.position.x > transform.position.x && transform.parent.localScale.x <0)
            {
                Flib();
            }
            else if(player.position.x< transform.position.x && transform.parent.localScale.x > 0)
            {
                Flib();
            }
        }
    }

    public bool IsPlayerInRange(float range)
    {
        // Check if the player is in range based on the provided range
        return Vector2.Distance(transform.position, player.position) <= range;
    }
    public void StartConversation()
    {
        // Show speech bubble or initiate dialogue here
        speechBubbleRenderer.enabled = true;
        // Add your code to initiate the dialogue sequence
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            speechBubbleRenderer.enabled=false;
            dialogNPC = FindObjectOfType<dialogueUI>();
            dialogNPC.dg();
        }
    }
    private void Flib()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.parent.localScale = currentScale;
    }


}
