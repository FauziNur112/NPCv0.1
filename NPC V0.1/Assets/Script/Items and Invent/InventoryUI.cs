using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;

    Inventory inventory;

    itemslot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = ItemsParent.GetComponentsInChildren<itemslot>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
