using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;

     void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Instance nya kebanyakan cok");
           
            return;
        }
        Instance = this;
    }
    #endregion

    public int Space = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        /*Mengecek jika item yang di inventori sudah sama dengan atau melebihi kapasitas (space) yang ditentukan
        Jika benar, maka abort the function*/
        if (items.Count >= Space)
        {
            Debug.Log("Kebak Cok");
            return false;
        }

        if (!item.IsDefaultItem)
        {
            items.Add(item);
            Debug.Log("Mengambil " + item.name);

            if (onItemChangedCallback != null)
            {
                /*Reference untuk script lain ketika fungsi ini dipanggil. Contohnya untuk UpdateUI inventory*/
                onItemChangedCallback.Invoke();
            }
            
        }
        return true;
       
    }

    /*Dari tutoril ada fungsi remove tapi belum pasti akan dipakai tidak*/
/*    public void Remove (Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }*/

}
