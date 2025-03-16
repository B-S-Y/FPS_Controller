using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera PlayerCamera;

    public float shakeMagnitude = 0.01f; // Titreme þiddeti
    public float shakeFrequency = 0.2f; // Titreme sýklýðý (saniyede kaç kez titreme olacaðý)
    public float dampingSpeed = 2.0f; // Titremenin durma hýzý


    private Vector3 initialPosition; // Kameranýn baþlangýç pozisyonu
    private float nextShakeTime = 0f; // Bir sonraki titreme zamaný
    private bool isSprinting = false; // Titreme aktif mi?


    public float normalFOV = 90f; // Normal Field of View
    public float sprintFOV = 60f; // Sprint Field of View
    public float fovChangeSpeed = 5f; // How fast the FOV changes

    void Start()
    {
        initialPosition = PlayerCamera.transform.localPosition; // Baþlangýç pozisyonunu kaydet
        PlayerCamera.fieldOfView = normalFOV; // Set the initial FOV
    }

    //if is sprinting ekle
    void Update()
    {
        if (isSprinting) //Player is Sprinting
        {
            // Titreme efekti aktifse ve zamaný geldiyse titreme uygula
            if (Time.time >= nextShakeTime)
            {
                PlayerCamera.transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                nextShakeTime = Time.time + shakeFrequency; // Bir sonraki titreme zamanýný ayarla
            }
            // Smoothly change the FOV based on sprinting state
            
            
            float targetFOV = sprintFOV;
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, targetFOV, fovChangeSpeed * Time.deltaTime);//Mathf.Lerp is often used in Update to create smooth transitions over time.smoothly change a camera's Field of View (FOV) or a light's intensity.
            
        }
        else
        {
            // Titreme efekti pasifse kamerayý yavaþça baþlangýç pozisyonuna geri getir
            PlayerCamera.transform.localPosition = Vector3.Lerp(PlayerCamera.transform.localPosition, initialPosition, Time.deltaTime * dampingSpeed);
            PlayerCamera.fieldOfView = normalFOV;
        }
    }

    public void StartShaking()
    {
        isSprinting = true; // Titremeyi baþlat
    }

    public void StopShaking()
    {
        isSprinting = false; // Titremeyi durdur
    }
}//using UnityEngine;

//public class CameraShake : MonoBehaviour
//{
//    public float shakeDuration = 0.5f; // Titreme süresini artýr
//    public float shakeMagnitude = 0.2f; // Titreme þiddetini azalt
//    public float dampingSpeed = 1.0f; // Titremenin zamanla azalma hýzý

//    private Vector3 initialPosition; // Kameranýn baþlangýç pozisyonu
//    private float currentShakeDuration = 0f; // Mevcut titreme süresi

//    void Start()
//    {
//        initialPosition = transform.localPosition; // Baþlangýç pozisyonunu kaydet
//    }

//    void Update()
//    {
//        if (currentShakeDuration > 0)
//        {
//            // Titreme efekti uygula
//            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

//            // Titreme süresini azalt
//            currentShakeDuration -= Time.deltaTime * dampingSpeed;
//        }
//        else
//        {
//            // Titreme bittiðinde kamerayý baþlangýç pozisyonuna geri getir
//            currentShakeDuration = 0f;
//            transform.localPosition = initialPosition;
//        }
//    }

//    public void ShakeCamera()
//    {
//        currentShakeDuration = shakeDuration; // Titreme süresini baþlat
//    }
//}