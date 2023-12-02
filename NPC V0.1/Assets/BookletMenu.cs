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
    GameObject Closing;
    

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
        Active(Obj);
    }


    public void BukaObj ()
    {
        if (!obj)
        {
            WillClose(Closing);
            Active(Obj);
        } 
        DeActivate();
        obj = true;
        Closing = Obj;
    }

    public void BukaMap()
    {
        if (!map)
        {
            WillClose(Closing);
            Active(Map);
        }
        DeActivate();
        map = true;
   
        Closing = Map;
    }

    public void BukaSetting()
    {
        if (!setting) 
        {
            WillClose(Closing);
            Active(Setting);
        }
        DeActivate();
        setting = true;
        Closing = Setting;
    }

    public void BukaInv()
    {
        if (!inv)
        {
            WillClose(Closing);
            Active(Inv);
        }
        DeActivate();
        inv = true;
        Closing=Inv;
    }

    public void Active (GameObject Membuka) 
    { 
        Membuka.transform.localPosition -= new Vector3(20, 0, 0);
    }

    public void DeActivate ()
    {
        obj = false;
        map = false;
        setting = false;
        inv = false;
        
    }

    private void WillClose (GameObject Closing)
    {
        Closing.transform.localPosition += new Vector3(20, 0, 0);
    }
}
