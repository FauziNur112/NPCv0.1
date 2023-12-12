using UnityEngine;
using UnityEngine.UI;



public class itemslot : MonoBehaviour
{
    public Image icon;
/*    public TMP_Text textMeshPro;*/
    Item item;



    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.Icon;
        icon.enabled = true;

/*        textMeshPro.text = item.name;
        textMeshPro.enabled = true;*/
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        // Reset UI text style when clearing the slot
/*        textMeshPro.fontStyle = FontStyles.Normal;*/
    }
}
