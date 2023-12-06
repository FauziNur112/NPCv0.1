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
    public bool senternyala;
    public bool powerBerkurang = false;
    private void Start()
    {
        currentSenter= maxSenter;
        SetMaxSenter(maxSenter);
    }

    void Update()
    {
        if (!powerBerkurang)
        {
            if (PlayerMov.senternyalatidak)
            {
                Debug.Log("Sampai disini berhasil");
                StartCoroutine("SenterPower");
                powerBerkurang= true;
            }
            else
            {
                StopCoroutine("SenterPower");
            }
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

    public IEnumerator SenterPower()
    {
        while (PlayerMov.senternyalatidak)
        {
            TakePower(2);
            yield return new WaitForSeconds(1);
        }
    }
}
