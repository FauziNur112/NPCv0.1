using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMov : MonoBehaviour, IDataPersistence
{
    public int maxSanity = 100;
    private int minSanity = 0;
    public int currentSanity;
    public SanityBar sanitybar;


    public float moveSpeed = 5f;
    public Transform senter;
    public Rigidbody2D rb;
    public float rotationSpeed = 2f;


    public GameObject Booklet;
    bool booklets = false;

    Vector2 movement;
    float rotationAngle = 0f;
    public float senterMoveSpeed = 2f;
    Vector3 senterTargetPosition;


    public Animator animator;


    private bool isSenterOn = false;    
    public GameObject Senter;
    public SenterBar senterBar;
    public bool senternyalatidak;
    Light2D senterLight;
    SpriteRenderer senterorderoflayer;


    void Start()
    {
        sanitybar.SetMaxSanity(maxSanity);
        sanitybar.SetSanity(currentSanity);
        senterLight = senter.GetComponent<Light2D>();
/*        senterorderoflayer = Senter.GetComponent<SpriteRenderer>();*/
    }


    private void Awake()
    {
        // Dapatkan referensi ke komponen Light2D dari senter
        Light2D senterLight = senter.GetComponent<Light2D>();

        // Periksa apakah senter memiliki komponen Light2D
        if (senterLight != null)
        {
            // Matikan lampu senter
            senterLight.enabled = false;
        }

        // Selanjutnya, tambahkan kode lain yang Anda butuhkan dalam metode Awake.
    }

    void Update()
    {
        currentSanity = Mathf.Clamp(currentSanity, minSanity, maxSanity);
        // Get the input axis values.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
 

/*        Debug.Log("Horizontal Input: " + horizontalInput);
        Debug.Log("Vertical Input: " + verticalInput);*/


        // Normalize the movement vector to ensure constant speed in all directions.
        movement = new Vector2(horizontalInput, verticalInput).normalized;

        /* 
         animator.SetFloat("Vertical", movement.y);
         */

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("horizontal", horizontalInput);
        animator.SetFloat("Vertikal", verticalInput);

        /*Menentukan rotasi senter dengan mendeteksi arah hadap player berdasarkan input dari GetAxisRaw*/
        if (verticalInput == 1)
        {
            if (horizontalInput == -1)
            {
                rotationAngle = 45f; // Up-Left

            }
            else if (horizontalInput == 1)
            {
                rotationAngle = -45f; // Up-Right

            }
            else
            {
                rotationAngle = 0f; // Up
            }
        }
        else if (verticalInput == -1)
        {
            if (horizontalInput == -1)
            {


                rotationAngle = 135f; // Down-Left
            }
            else if (horizontalInput == 1)
            {
 

                rotationAngle = -135f; // Down-Right
            }
            else
            {


                rotationAngle = 180f; // Down
/*                senterorderoflayer.sortingOrder = 2*/;
            }
        }
        else if (horizontalInput == -1)
        {


            rotationAngle = 90f; // Left
        }
        else if (horizontalInput == 1)
        {
            rotationAngle = -90f; // Right
        }
        /*   if (Input.GetKeyDown(KeyCode.E))
           {
               if (Inventory.Instance.hasFlashlight)
               {
                   isSenterOn = !isSenterOn;
                   senter.gameObject.SetActive(isSenterOn);
               }
               else
               {
                   // Tampilkan pesan bahwa pemain tidak memiliki senter
                   Debug.Log("Tidak memiliki senter!");
               }
           }

           // Check if the "E" key is pressed and the flashlight is already on.
           if (Input.GetKeyDown(KeyCode.E) && isSenterOn)
           {
               isSenterOn = false;
               senter.gameObject.SetActive(false);
           }
   */
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            bool OnOffSenter = Inventory.Instance.HasItem("senter");
            if (OnOffSenter)
            {
                if (!nyala)
                {
                    Debug.Log("NYALA");
                    Senter.SetActive(true);
                    senterBar.senternyala = true;
                } else
                {
                    Senter.SetActive(false);
                    senterBar.senternyala = false;
                    Debug.Log("MATI");
                }   
            } else 
            {
                Debug.Log("Lu gak punya senter");
            }
        }*/


        if (Input.GetKeyDown(KeyCode.F))
        {
            // Periksa apakah pemain memiliki item "Senter" dalam inventori
            if (Inventory.Instance.HasItem("Senter"))
            {
                // Dapatkan referensi ke komponen Light2D dari senter
                

                // Periksa apakah senter memiliki komponen Light2D
                if (senterLight != null && senterBar.currentSenter > 0)
                {
                    // Ganti status senter (nyalakan jika mati, atau matikan jika menyala)
                    senterLight.enabled = !senterLight.enabled;
                    if (senterLight.enabled)
                    {
                        senternyalatidak = true;
                    } else
                    {
                        senternyalatidak = false;
                        senterBar.powerBerkurang = false;
                    }
                }
            }
            else
            {
                Debug.Log("Anda tidak memiliki senter dalam inventori.");
            }
        }

        if (senterBar.currentSenter == 0 && senternyalatidak)
        {
            
            senterLight.enabled = !senterLight.enabled;
            senternyalatidak = false;
            senterBar.powerBerkurang = false;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Inventory.Instance.HasItem("Baterai"))
            {
                Debug.Log("Sampai sini");
                senterBar.TambahPower();
                Inventory.Instance.FindAndDestroy("Baterai");
            }
            else
            {
     
            }
        }


        // Gunakan ini jika ingin senter berputar secara instan
        /*        senter.localRotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));*/

        /*Menyimpan target rotasi*/
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));

        /*Gunakan ini jika ingin senter rotasi pada axis z secara perlahan*/
        senter.localRotation = Quaternion.Slerp(senter.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!booklets)
            {
                Debug.Log("Berhasil buka map");
                BukaBooklet();
            }
            else
            {
                TutupBooklet();
            }
        }

  
    }

    bool HasSenterInInventory()
    {
        // Di sini, Anda perlu mengganti ini dengan cara yang sesuai
        // untuk memeriksa apakah pemain memiliki item "Senter" dalam inventori mereka
        // Anda dapat menggunakan referensi ke skrip Inventory atau metode lain
        // yang Anda gunakan untuk memeriksa inventori pemain.

        // Contoh sederhana: cek apakah item dengan nama "Senter" ada dalam inventori
        if (Inventory.Instance != null)
        {
            foreach (Item item in Inventory.Instance.items)
            {
                if (item.name == "Senter")
                {
                    return true;
                } 
            }
        }
        return false;
    }
    void FixedUpdate()
    {
        // Calculate the target position (Player).
        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Move the player to the target position.
        rb.MovePosition(targetPosition);

    }

    public void TakeDamage(int damage)
    {
        currentSanity -= damage;
        sanitybar.SetSanity(currentSanity);
    }

    private void BukaBooklet()
    {
        Booklet.SetActive(true);
/*        housemap = diary.transform.Find("maps").gameObject;
        housemap.SetActive(true);*/
        Time.timeScale = 0f;
        booklets = true;
    }

    private void TutupBooklet ()
    {
        Booklet.SetActive(false);
        Time.timeScale = 1.0f;
        booklets = false;
    }

    public void LoadData(GameData data)
    {
        this.currentSanity = data.currentSanity;
        sanitybar.SetSanity(currentSanity);
        rb.position = data.Playerpos;
        
    }

    public void SaveData(ref GameData data)
    {
        data.currentSanity = this.currentSanity;
        data.Playerpos = rb.position;
    }
}
