
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public bool isFlashlight = false; // Tambahkan properti ini

    new public string name = "New Item";
    public Sprite Icon = null;
    public bool IsDefaultItem = false;
}
