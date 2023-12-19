using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenterBar : MonoBehaviour, IDataPersistence
{
    public PlayerMov PlayerMov;
    public Slider Senterslider;
    public int maxSenter = 100;
    int minSenter = 0;
    public int currentSenter;
    public bool senternyala;
    public bool powerBerkurang = false;
    private void Start()
    {

        Senterslider.maxValue = maxSenter;
        Senterslider.value = currentSenter;
/*
        SetMaxSenter(maxSenter);
        setSenter(currentSenter);*/
    }

    void Update()
    {
        currentSenter = Mathf.Clamp(currentSenter, minSenter, maxSenter);

        if (!powerBerkurang)
        {
            if (PlayerMov.senternyalatidak)
            {

                StartCoroutine("SenterPower");
                powerBerkurang = true;
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

    public void TambahPower()
    {
        currentSenter += 20;
        setSenter(currentSenter);
    }

    public void LoadData(GameData data)
    {
        this.currentSenter = data.currentSenter;
        setSenter(currentSenter);
    }

    public void SaveData(ref GameData data)
    {
        data.currentSenter = this.currentSenter;
    }
}
