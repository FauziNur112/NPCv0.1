
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    Transform player;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void interact ()
    {
        Debug.Log("interacting with " + transform.name);
    }

    void Start ()
    {
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        float distances = Vector3.Distance(player.position, transform.position);
       
        if (distances <= radius)
        {
            interact();
            
        }
    }
}
