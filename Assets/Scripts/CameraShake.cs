using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeMagnitude = 0.01f; // Titreme þiddeti
    public float shakeFrequency = 0.2f; // Titreme sýklýðý (saniyede kaç kez titreme olacaðý)
    public float dampingSpeed = 2.0f; // Titremenin durma hýzý

    private Vector3 initialPosition; // Kameranýn baþlangýç pozisyonu
    private float nextShakeTime = 0f; // Bir sonraki titreme zamaný
    private bool isShaking = false; // Titreme aktif mi?

    void Start()
    {
        initialPosition = transform.localPosition; // Baþlangýç pozisyonunu kaydet
    }

    void Update()
    {
        if (isShaking)
        {
            // Titreme efekti aktifse ve zamaný geldiyse titreme uygula
            if (Time.time >= nextShakeTime)
            {
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                nextShakeTime = Time.time + shakeFrequency; // Bir sonraki titreme zamanýný ayarla
            }
        }
        else
        {
            // Titreme efekti pasifse kamerayý yavaþça baþlangýç pozisyonuna geri getir
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime * dampingSpeed);
        }
    }

    public void StartShaking()
    {
        isShaking = true; // Titremeyi baþlat
    }

    public void StopShaking()
    {
        isShaking = false; // Titremeyi durdur
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