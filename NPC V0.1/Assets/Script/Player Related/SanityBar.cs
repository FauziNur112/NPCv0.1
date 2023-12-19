using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Slider Sanityslider;
    public PlayerMov playercontrol;
    public StoryManager storymanager;
    public void SetMaxSanity (int sanity)
    {
        Sanityslider.maxValue = sanity;
        Sanityslider.value = sanity;
    }

    public void SetSanity (int sanity)
    {
        Sanityslider.value = sanity;
    }

    void Update ()
    {
        if (playercontrol.senternyalatidak == false && storymanager.lampuGlobal.intensity < 11.2f)
        {
            StartCoroutine("SenterOffDamage", playercontrol);
        } else
        {
            StopCoroutine("SenterOffDamage");
        }
    }

    IEnumerator SenterOffDamage( PlayerMov playercontrol)
    {
        while (playercontrol.senternyalatidak == false && storymanager.lampuGlobal.intensity < 11.2f)
        {
            yield return new WaitForSeconds(1);
            int banyakdamage = 2;
            playercontrol.TakeDamage(banyakdamage);
            yield return new WaitForSeconds(1);
        }


    }
}
