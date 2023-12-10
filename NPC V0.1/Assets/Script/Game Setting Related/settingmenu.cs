using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingmenu : MonoBehaviour
{
    /*Deklarasi variable untuk menerima assets audio mixer*/
    public AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadVolume();
        } else
        {
            setVolume();
        }
        
    }

    /*Fungsi untuk menerima value master slider pada setting di main menu*/
    public void setVolume ()
    {
        float volume = masterSlider.value;
        /*Volume pertama adalah paramter variable audio mixer, volume kedua dari master slider*/
        audioMixer.SetFloat("volume", volume * -1 + 20);
        /*        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 2);*/
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }
}
