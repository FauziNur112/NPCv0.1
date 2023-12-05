
using UnityEngine;

using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

public class Interactable : MonoBehaviour
{
    public Item item;
    public float radius = 3f;
    Transform player;
    public Transform InteractionTransform;
    public bool hasInteracted = false;

    private void OnDrawGizmosSelected()
    { 
        /*Deklatasi jika gameObjecy dari interactionTransform belum di assign, maka automatis assign ke gameObject 
        yang ditempeli script ini*/
        if (InteractionTransform == null)
        {
            InteractionTransform = transform;
        }

        /*Draw radius deteksi interaksi dengan player*/
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }

    /*Fungsi yang dapat di over write ketika di panggil. Sebab masing2 item ada behaviour interact tersendiri*/
    public virtual void interact ()
    {
        Debug.Log(hasInteracted);

/*        if (item != null && item.name == "Battery")
        {
            // Notify Inventory script about picking up a battery
            Inventory.Instance.OnBatteryPickedUp();
        }*/
    }

    void Start ()
    {
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        /*Variable distance adalah jarak dari player ke gameObject dari script ini (InteractionTransform)*/
        float distances = Vector3.Distance(player.position, InteractionTransform.position);
       
        /*Cek apakah interaction terjadi namun membatasi untuk satu kali, jadi tidak cek setiap update*/
        if (distances <= radius)
        {
            if (!hasInteracted) 
            {
                interact();
                hasInteracted = true;
            } 
            
            
        } else
        {
            hasInteracted = false;
        }

        /*Jika interaksi terjadi (true) dan player input key 'I', maka item ditambahkan ke list inventory dan item 
        yang berada di scene akan dihapus*/
        if (hasInteracted && Input.GetKeyDown(KeyCode.I))
        {
            bool wasPickedUp = Inventory.Instance.Add(item);
            
            /*Merujuk dari script inventory, jika item benar diambil maka gameObject item akan dihancurkan.*/
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
