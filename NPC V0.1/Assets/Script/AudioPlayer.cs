using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxAudioSource;
    [SerializeField]
    private AudioSource bgmAudioSource;

    [SerializeField]
    private List<AudioClip> sfxClip;

    [SerializeField]
    private List<AudioClip> bgmClip;

  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
