
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
        if (InteractionTransform == null)
        {
            InteractionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }

    public virtual void interact ()
    {
        Debug.Log(hasInteracted);
    }

    void Start ()
    {
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        float distances = Vector3.Distance(player.position, InteractionTransform.position);
       
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

        if (hasInteracted && Input.GetKeyDown(KeyCode.I))
        {
            bool wasPickedUp = Inventory.Instance.Add(item);
            
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
            
           
        }


    }
}
