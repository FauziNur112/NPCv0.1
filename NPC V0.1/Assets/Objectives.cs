using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public List<string> listGoal = new List<string>();
    public int checkedroom = 0;
    public GameObject listobj;
    public GameObject listobj2;

    TMP_Text[] listTujuan;
    TMP_Text[] listTujuan2;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(listTujuan.Length);
    }

    private void Awake()
    { 
        listTujuan = listobj.GetComponentsInChildren<TMP_Text>();
        listTujuan2 = listobj2.GetComponentsInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrentObjectives()
    {
        
    }

    public void actOne()
    {
        listGoal.Clear();
        listGoal.Add("Menuju Tempat Tidur untuk Istirahat");
        UpdateObjectives();
    }

    public void actTwo()
    {
        listGoal.Clear();
        listGoal.Add("Cek Sumber Suara!");
        UpdateObjectives();
    }

    public void actThree()
    {
        listGoal.Clear();
        listGoal.Add("Kembali ke Kamar dan Tidur!");
        UpdateObjectives();
    }

    public void actFour()
    {
        listGoal.Clear();
        listGoal.Add("Perbaiki Box Listrik!");
        UpdateObjectives();
    }

    public void actFive()
    {
        listGoal.Clear();
        listGoal.Add("Cek Sumeber Suara!");
        UpdateObjectives();
    }

    public void actSix()
    {
        listGoal.Clear();
        listGoal.Add("Cepat Kabur ke Kamar!");
        UpdateObjectives();
    }

    public void actSeven()
    {
        listGoal.Clear();
        listGoal.Add("Geledah Semua Ruangan untuk Mendapatkan Baterai!");
        listGoal.Add("Ruangan Yang Sudah digeledah: " + checkedroom);
        UpdateObjectives();
    }

    public void UpdateObjectives()
    {

        for (int i = 0; i < listGoal.Count; i++)
        {
            listTujuan[i + 1].text = listGoal[i];
            listTujuan2[i + 1].text = listGoal[i];
        }

    }

}


