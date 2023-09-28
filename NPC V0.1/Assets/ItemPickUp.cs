
using UnityEngine;

public class ItemPickUp : Interactable
{
    public override void interact()
    {

        Debug.Log("interacted with" + transform.name);
        base.interact();

    }

    void PickUp() 
    {
    }


}
