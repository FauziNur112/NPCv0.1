using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        var dir = Target.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void OnChangeGoal(GameObject objTujuan)
    {
        Target = objTujuan.GetComponent<Transform>();
    }
}
