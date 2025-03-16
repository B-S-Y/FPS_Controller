using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera PlayerCamera;

    public float shakeMagnitude = 0.01f; // Titreme �iddeti
    public float shakeFrequency = 0.2f; // Titreme s�kl��� (saniyede ka� kez titreme olaca��)
    public float dampingSpeed = 2.0f; // Titremenin durma h�z�


    private Vector3 initialPosition; // Kameran�n ba�lang�� pozisyonu
    private float nextShakeTime = 0f; // Bir sonraki titreme zaman�
    private bool isSprinting = false; // Titreme aktif mi?


    public float normalFOV = 90f; // Normal Field of View
    public float sprintFOV = 60f; // Sprint Field of View
    public float fovChangeSpeed = 5f; // How fast the FOV changes

    void Start()
    {
        initialPosition = PlayerCamera.transform.localPosition; // Ba�lang�� pozisyonunu kaydet
        PlayerCamera.fieldOfView = normalFOV; // Set the initial FOV
    }

    //if is sprinting ekle
    void Update()
    {
        if (isSprinting) //Player is Sprinting
        {
            // Titreme efekti aktifse ve zaman� geldiyse titreme uygula
            if (Time.time >= nextShakeTime)
            {
                PlayerCamera.transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                nextShakeTime = Time.time + shakeFrequency; // Bir sonraki titreme zaman�n� ayarla
            }
            // Smoothly change the FOV based on sprinting state
            
            
            float targetFOV = sprintFOV;
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, targetFOV, fovChangeSpeed * Time.deltaTime);//Mathf.Lerp is often used in Update to create smooth transitions over time.smoothly change a camera's Field of View (FOV) or a light's intensity.
            
        }
        else
        {
            // Titreme efekti pasifse kameray� yava��a ba�lang�� pozisyonuna geri getir
            PlayerCamera.transform.localPosition = Vector3.Lerp(PlayerCamera.transform.localPosition, initialPosition, Time.deltaTime * dampingSpeed);
            PlayerCamera.fieldOfView = normalFOV;
        }
    }

    public void StartShaking()
    {
        isSprinting = true; // Titremeyi ba�lat
    }

    public void StopShaking()
    {
        isSprinting = false; // Titremeyi durdur
    }
}//using UnityEngine;

//public class CameraShake : MonoBehaviour
//{
//    public float shakeDuration = 0.5f; // Titreme s�resini art�r
//    public float shakeMagnitude = 0.2f; // Titreme �iddetini azalt
//    public float dampingSpeed = 1.0f; // Titremenin zamanla azalma h�z�

//    private Vector3 initialPosition; // Kameran�n ba�lang�� pozisyonu
//    private float currentShakeDuration = 0f; // Mevcut titreme s�resi

//    void Start()
//    {
//        initialPosition = transform.localPosition; // Ba�lang�� pozisyonunu kaydet
//    }

//    void Update()
//    {
//        if (currentShakeDuration > 0)
//        {
//            // Titreme efekti uygula
//            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

//            // Titreme s�resini azalt
//            currentShakeDuration -= Time.deltaTime * dampingSpeed;
//        }
//        else
//        {
//            // Titreme bitti�inde kameray� ba�lang�� pozisyonuna geri getir
//            currentShakeDuration = 0f;
//            transform.localPosition = initialPosition;
//        }
//    }

//    public void ShakeCamera()
//    {
//        currentShakeDuration = shakeDuration; // Titreme s�resini ba�lat
//    }
//}