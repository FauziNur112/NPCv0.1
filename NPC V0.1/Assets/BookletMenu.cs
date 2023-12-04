using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class BookletMenu : MonoBehaviour
{
    public GameObject Obj;
    public GameObject Map;
    public GameObject Setting;
    public GameObject Inv;
    public GameObject MenuAbout;
    public GameObject MenuMap;
    public GameObject MenuSetting;
    public GameObject MenuInventory;
    GameObject Closing;
    GameObject Menutup;
    

    bool obj;
    bool map;
    bool setting;
    bool inv;
    string BukadanTutup;


    public static BookletMenu Instance; 
    void Awake() 
    { 
        Instance = this;
        obj = true;
        BukaObj();
        Active(Obj, MenuAbout);
    }


    public void BukaObj ()
    {
        if (!obj)
        {
            WillClose(Closing, Menutup);
            Active(Obj, MenuAbout);
        } 
        DeActivate();
        obj = true;
        Closing = Obj;
        Menutup = MenuAbout;
    }

    public void BukaMap()
    {
        if (!map)
        {
            WillClose(Closing, Menutup);
            Active(Map, MenuMap);
        }
        DeActivate();
        map = true;
   
        Closing = Map;
        Menutup = MenuMap;
    }

    public void BukaSetting()
    {
        if (!setting) 
        {
            WillClose(Closing, Menutup);
            Active(Setting, MenuSetting);
        }
        DeActivate();
        setting = true;
        Closing = Setting;
        Menutup = MenuSetting;
    }

    public void BukaInv()
    {
        if (!inv)
        {
            WillClose(Closing, Menutup);
            Active(Inv, MenuInventory);
        }
        DeActivate();
        inv = true;
        Closing=Inv;
        Menutup=MenuInventory;
    }

    public void Active (GameObject Membuka, GameObject Melihat) 
    { 
        Membuka.transform.localPosition -= new Vector3(20, 0, 0);
        Melihat.SetActive(true);
    }

    public void DeActivate ()
    {
        obj = false;
        map = false;
        setting = false;
        inv = false;
        
    }

    private void WillClose (GameObject Closing, GameObject Menutup)
    {
        Closing.transform.localPosition += new Vector3(20, 0, 0);
        Menutup.SetActive(false);
    }
}
