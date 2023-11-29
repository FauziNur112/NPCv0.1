using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Slider Sanityslider;

    public void SetMaxSanity (int sanity)
    {
        Sanityslider.maxValue = sanity;
        Sanityslider.value = sanity;
    }

    public void SetSanity (int sanity)
    {
        Sanityslider.value = sanity;
    }

}
