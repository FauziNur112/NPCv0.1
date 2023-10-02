using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform senter;
    public Rigidbody2D rb;
    public float rotationSpeed = 2f;

    Vector2 movement;
    float rotationAngle = 0f;
    public float senterMoveSpeed = 2f;
    Vector3 senterTargetPosition;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    void Update()
    {
        // Get the input axis values.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log("Horizontal Input: " + horizontalInput);
        Debug.Log("Vertical Input: " + verticalInput);

        // Normalize the movement vector to ensure constant speed in all directions.
        movement = new Vector2(horizontalInput, verticalInput).normalized;


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



        // Gunakan ini jika ingin senter berputar secara instan
        /*        senter.localRotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));*/

        /*Menyimpan target rotasi*/
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));

        /*Gunakan ini jika ingin senter rotasi pada axis z secara perlahan*/
        senter.localRotation = Quaternion.Slerp(senter.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

    }

    void FixedUpdate()
    {
        // Calculate the target position (Player).
        Vector2 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Move the player to the target position.
        rb.MovePosition(targetPosition);

    }

}
