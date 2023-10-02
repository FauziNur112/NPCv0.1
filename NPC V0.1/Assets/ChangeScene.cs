using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class ChangeScene : MonoBehaviour
{
    public PlayerDots dots;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has a specific tag (optional).
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            // You can perform actions here when the player enters the trigger.
            dots.PindahDots(1);
            SceneManager.LoadScene("MainHallway");
            

        }

       
    }
}
