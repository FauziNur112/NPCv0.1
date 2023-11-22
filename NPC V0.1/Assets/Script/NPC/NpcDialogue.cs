using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;
    private SpriteRenderer speechBubbleRenderer;
   
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            speechBubbleRenderer.enabled=false;
        }
    }
    private void Flib()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.parent.localScale = currentScale;
    }


}