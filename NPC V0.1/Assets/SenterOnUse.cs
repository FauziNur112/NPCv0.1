using UnityEngine;

public class SenterOnUse : MonoBehaviour
{
    public SenterBar senterBar;
    public Item item;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Inventory.Instance.HasItem("Baterai"))
            {
                Debug.Log("Sampai sini");
                senterBar.TambahPower();
                Destroy(this);
            }
            else
            {
                Debug.Log("LU KAGAK PUNYA BATRE COK");
            }
        }
    }

}
