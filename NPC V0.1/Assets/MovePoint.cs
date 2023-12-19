using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovePoint : MonoBehaviour
{
    // Start is called before the first frame update

    public void relocate (GameObject go)
    {
        Vector3 center = go.transform.position;

        
        transform.position = center;
    }
}
