using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class triggerleveltiga : MonoBehaviour
{
    public PlayableDirector leveltiga;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        leveltiga.Play();
    }
}
