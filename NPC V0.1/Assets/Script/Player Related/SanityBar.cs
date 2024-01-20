using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Slider Sanityslider;
    public PlayerMov playercontrol;
    public StoryManager storymanager;
    public bool lampuMati = false;
    public void SetMaxSanity(int sanity)
    {
        Sanityslider.maxValue = sanity;
        Sanityslider.value = sanity;
    }

    public void SetSanity(int sanity)
    {
        Sanityslider.value = sanity;
    }

    void FixedUpdate()
    {
            if (!lampuMati)
            {
                lampuMati = true;

                StartCoroutine("SenterOffDamage", playercontrol);
            }

            if (storymanager.lampuGlobal.intensity > 11f)
        {
            lampuMati= false;
            StopCoroutine("SenterOffDamage");
        }

            if (Sanityslider.value == 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    IEnumerator SenterOffDamage( PlayerMov playercontrol)
    {
 
            while (storymanager.lampuGlobal.intensity < 11.2f)
            {
            if (playercontrol.senternyalatidak == false)
            {
                int banyakdamage = 2;
                playercontrol.TakeDamage(banyakdamage);
                
            }
            yield return new WaitForSeconds(5);
        }

           


    }
}
