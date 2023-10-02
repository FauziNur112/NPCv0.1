using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDots : MonoBehaviour
{
    public Transform[] lokasi;
    public int codesloc;
    public void PindahDots(int kodelokasi)
    {
        Transform onMaps = lokasi[kodelokasi];
        Vector2 dots = onMaps.position;
        this.transform.position = dots;
    }

    void Start()
    {
        PindahDots(codesloc);
    }

}
