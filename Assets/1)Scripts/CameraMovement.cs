using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensitivity = 1000f;

    public Transform Player;
    public Transform PlayerCamera;
    private float xRotation = 0f; // Dikey dönüþ açýsý


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        // Dikey dönüþü hesapla (yukarý-aþaðý bakýþ)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Bakýþ açýsýný sýnýrlanýr 180 derece olarak

        // Kamerayý düþeyde döndür
        transform.rotation = Quaternion.Euler(xRotation, 0f, 0f);


        // Karakteri ve kamerayý yatayda döndür (saða-sola bakýþ)

        PlayerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (left and right) - rotate the player object
        Player.Rotate(Vector3.up * mouseX);

    }
}
