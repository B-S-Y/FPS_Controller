using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensitivity = 1000f;

    public Transform Player;
    public Transform PlayerCamera;
    private float xRotation = 0f; // Dikey d�n�� a��s�


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        // Dikey d�n��� hesapla (yukar�-a�a�� bak��)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Bak�� a��s�n� s�n�rlan�r 180 derece olarak

        // Kameray� d��eyde d�nd�r
        transform.rotation = Quaternion.Euler(xRotation, 0f, 0f);


        // Karakteri ve kameray� yatayda d�nd�r (sa�a-sola bak��)

        PlayerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (left and right) - rotate the player object
        Player.Rotate(Vector3.up * mouseX);

    }
}
