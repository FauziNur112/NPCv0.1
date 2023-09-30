using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class settingmenu : MonoBehaviour
{
    /*Deklarasi variable untuk menerima assets audio mixer*/
    public AudioMixer audioMixer;


        /*Fungsi untuk menerima value master slider pada setting di main menu*/
        public void setVolume (float volume)
    {

        /*Volume pertama adalah paramter variable audio mixer, volume kedua dari master slider*/
        audioMixer.SetFloat("volume", volume * -1 + 20);
    }
}
