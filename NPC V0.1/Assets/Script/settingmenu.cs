using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class settingmenu : MonoBehaviour
{
    public AudioMixer audioMixer;
        public void setVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume * -1 + 20);
    }
}