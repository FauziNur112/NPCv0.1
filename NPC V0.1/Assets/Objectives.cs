using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public List<string> listGoal = new List<string>();
    public int checkedroom = 0;
    public GameObject listobj;

    TMP_Text[] listTujuan;

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(listTujuan.Length);
    }

    private void Awake()
    { 
        listTujuan = listobj.GetComponentsInChildren<TMP_Text>();
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
        listGoal.Add("Selidiki Sumber Suara Kucing!");
        UpdateObjectives();
    }

    public void actTwo()
    {
        listGoal.Clear();
        listGoal.Add("Cari Tempat Tidurmu dan Tidur!");
        UpdateObjectives();
    }

    public void actThree()
    {
        listGoal.Clear();
        listGoal.Add("Cari Box Listrik dan Perbaiki!");
        UpdateObjectives();
    }

    public void actFour()
    {
        listGoal.Clear();
        listGoal.Add("Perbaiki Box Listrik Lagi!");
        UpdateObjectives();
    }

    public void actFive()
    {
        listGoal.Clear();
        listGoal.Add("Cari Box Listrik dan Perbaiki!");
        UpdateObjectives();
    }

    public void actSix()
    {
        listGoal.Clear();
        listGoal.Add("Selidiki Sumber Suara!");
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
        }
        Debug.Log(" IsCalled ");
    }

}


