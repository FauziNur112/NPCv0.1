using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Buat script baru
// Buat script baru
public class MovableText : MonoBehaviour
{
    // Deklarasi variabel
    public Text text;
    public Vector3 moveSpeed = Vector3.zero;

    // Update
    private void Update()
    {
        // Pindahkan text
        text.transform.position += moveSpeed;
    }
}

