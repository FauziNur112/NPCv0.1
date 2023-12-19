using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViaAudio : MonoBehaviour
{
    public Transform Player;
    public Transform Enemy;
    public PlayerMov playercontrol;
    float wait = 4;
    public bool Dekatmusuh = false;
    private IEnumerator dot;
    float distances;


    private void Start()
    {
        
        dot = AudioDamage(distances, playercontrol);
    }

    void Update()
    {
        distances = Vector3.Distance(Player.position, Enemy.position);
        if (distances < 40)
        {
            if (!Dekatmusuh)
            {
                Dekatmusuh = true;
             
                StartCoroutine(dot);
            }
        }
        else
        {
            Dekatmusuh = false;
            StopCoroutine(dot);
        }

     
    }
    

    IEnumerator AudioDamage(float distances, PlayerMov playercontrol)
    {
        while (distances < 40)
        {
            int banyakdamage = 5;
            if (distances < 20)
            {
                banyakdamage = 15;
            }
            playercontrol.TakeDamage(banyakdamage);
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Masih Jalan");
        
    }
}

