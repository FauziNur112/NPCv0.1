using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenterBar : MonoBehaviour
{
    public PlayerMov PlayerMov;
    public Slider Senterslider;
    public int maxSenter = 100;
    public int currentSenter;

    private void Start()
    {
        currentSenter= maxSenter;
        SetMaxSenter(maxSenter);
    }

    void Update()
    {
        Debug.Log(PlayerMov.nyala);
        if (PlayerMov.nyala)
        {
            Debug.Log("Sampai disini berhasil");
            StartCoroutine("SenterPower");
        } else
        {
            StopCoroutine("SenterPower");
        }
    }
    public void SetMaxSenter(int senter)
    {
        Senterslider.maxValue = senter;
        Senterslider.value = senter;
    }

    public void setSenter(int senter)
    {
        Senterslider.value = senter;
    }

    public void TakePower (int power)
    {
        currentSenter-= power;
        setSenter(currentSenter);
    }

    IEnumerator SenterPower(bool senterNyala)
    {
/*        while (senterNyala == true)
        {*/
            TakePower(2);
            yield return new WaitForSeconds(1);
/*        }*/
        Debug.Log("Masih Jalan");

    }
}
