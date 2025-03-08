using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeMagnitude = 0.01f; // Titreme �iddeti
    public float shakeFrequency = 0.2f; // Titreme s�kl��� (saniyede ka� kez titreme olaca��)
    public float dampingSpeed = 2.0f; // Titremenin durma h�z�

    private Vector3 initialPosition; // Kameran�n ba�lang�� pozisyonu
    private float nextShakeTime = 0f; // Bir sonraki titreme zaman�
    private bool isShaking = false; // Titreme aktif mi?

    void Start()
    {
        initialPosition = transform.localPosition; // Ba�lang�� pozisyonunu kaydet
    }

    void Update()
    {
        if (isShaking)
        {
            // Titreme efekti aktifse ve zaman� geldiyse titreme uygula
            if (Time.time >= nextShakeTime)
            {
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                nextShakeTime = Time.time + shakeFrequency; // Bir sonraki titreme zaman�n� ayarla
            }
        }
        else
        {
            // Titreme efekti pasifse kameray� yava��a ba�lang�� pozisyonuna geri getir
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime * dampingSpeed);
        }
    }

    public void StartShaking()
    {
        isShaking = true; // Titremeyi ba�lat
    }

    public void StopShaking()
    {
        isShaking = false; // Titremeyi durdur
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