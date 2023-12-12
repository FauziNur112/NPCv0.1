
using UnityEngine;
using UnityEngine.VFX;

public class Interactable : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate Guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public Item item;
    public float radius = 3f;
    Transform player;
    public Transform InteractionTransform;
    public bool hasInteracted = false;
    public SenterBar senterBar;
    public bool diambil = false;
    public bool wasPickedUp;



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
            wasPickedUp  = Inventory.Instance.Add(item);

            /*Merujuk dari script inventory, jika item benar diambil maka gameObject item akan dihancurkan.*/
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
        }


    }

    public void LoadData(GameData data)
    {
        data.itemcollected.TryGetValue(id, out wasPickedUp);
        if (wasPickedUp)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.itemcollected.ContainsKey(id))
        {
            data.itemcollected.Remove(id);
        }
        data.itemcollected.Add(id, wasPickedUp);
    }

}
