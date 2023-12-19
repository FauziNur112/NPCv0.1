using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matikanLampu : MonoBehaviour
{
    public StoryManager StoryManager;
    public int CountOff = 0;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CountOff < 2)
        {
            StoryManager.lampuGlobal.intensity = 0;
            CountOff++;
        }
    }
}
