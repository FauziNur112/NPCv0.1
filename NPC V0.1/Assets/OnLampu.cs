using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OnLampu : MonoBehaviour
{
    public float radius = 3f;
    public GameObject player;
    public GameObject hantu;
    public bool interacted;
    public StoryManager storyManager;
    public GameObject keenam;
    public GameObject triggermati;

    public matikanLampu matikanLampu;
    private void OnDrawGizmosSelected()
    {
        /*Deklatasi jika gameObjecy dari interactionTransform belum di assign, maka automatis assign ke gameObject 
        yang ditempeli script ini*/


        /*Draw radius deteksi interaksi dengan player*/
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }




    void Update()
    {
        float distances = Vector3.Distance(player.transform.position, transform.position);

        /*Cek apakah interaction terjadi namun membatasi untuk satu kali, jadi tidak cek setiap update*/
        if (distances <= radius)
        {
            if (!interacted)
            {

                interacted = true;
            }


        }
        else
        {
            interacted = false;
        }

        if (interacted && Input.GetKeyDown(KeyCode.E))
        {
            triggermati.SetActive(true);
            storyManager.lampuGlobal.intensity = 11.2f;
            hantu.SetActive(false);
            if (matikanLampu.CountOff >1)
            {
                triggermati.SetActive(false);
            }
            
        }

    }

       
}
       