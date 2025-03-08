using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    public float normalFOV = 60f; // Normal Field of View
    public float sprintFOV = 90f; // Sprint Field of View
    public float fovChangeSpeed = 5f; // How fast the FOV changes

    public Camera PlayerCamera; // Reference to the camera component

    void Start()
    {

        PlayerCamera.fieldOfView = normalFOV; // Set the initial FOV
    }

    void Update()
    {


        // Smoothly change the FOV based on sprinting state
        float targetFOV = sprintFOV;
        PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, targetFOV, fovChangeSpeed * Time.deltaTime);//Mathf.Lerp is often used in Update to create smooth transitions over time.smoothly change a camera's Field of View (FOV) or a light's intensity.
    }
}