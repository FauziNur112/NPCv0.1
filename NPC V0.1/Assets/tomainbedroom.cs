using UnityEngine;
using UnityEngine.SceneManagement;

public class tomainbedroom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has a specific tag (optional).
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            // You can perform actions here when the player enters the trigger.

            SceneManager.LoadScene("MainBedroom");
        }
    }
}
