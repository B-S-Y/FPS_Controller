using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting; // For TextMeshPro???
public class InteractionSystem : MonoBehaviour
{


    public Transform MainCamera;
    public TextMeshProUGUI textMeshProUI; // Reference to the UI TextMeshPro element
    public GameObject targetObject;
    public GameObject objectToSpawn;
    Vector3 spawnPosition;
    void Start()
    {
        textMeshProUI.enabled = false;
         spawnPosition = targetObject.transform.position;
    }

    void Update()
    {

        Raycast();

    }
    public void Raycast()
    {

        //                 position                       direction                      
        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);

        RaycastHit hit; // G�nderilecek ���n�n belirli layermasklere �arp�p �arpmayaca�� tutulur.

        int layerMask = LayerMask.GetMask("IntCube");

        //ray holds both the position and direction
        if (Physics.Raycast(ray, out hit, 6f, layerMask))
        {
            Debug.Log("Hit");
            textMeshProUI.enabled = true;//player can now see the text

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.CompareTag("ColorCube")) //.tranform da kullan�labilirdi burdaki ama� GamObjecte ula�mak ��nk�
                {
                    // �arp���lan objenin Renderer bile�enini al
                    Renderer renderer = hit.collider.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Rastgele bir renk olu�tur
                        Color randomColor = Random.ColorHSV();

                        // Objenin rengini de�i�tir
                        renderer.material.color = randomColor;

                        // Debug: Rastgele rengi konsola yazd�r
                        Debug.Log("Yeni Renk: " + randomColor);
                    }
                }

                else if (hit.collider.CompareTag("DestroyCube"))
                {
                    //Destroy(hit.collider); Obviously only destroys collider not the whole object
                    Destroy(hit.collider.gameObject);
                }

                else if (hit.collider.CompareTag("SpawnCube"))
                {
                    // Hedef nesnenin Renderer bile�enini al
                    Renderer targetRenderer = targetObject.GetComponent<Renderer>();

                    // Hedef nesnenin �st�ndeki pozisyonu hesapla
                    
                    spawnPosition.y += targetRenderer.bounds.extents.y; // Hedef nesnenin yar� y�ksekli�i

                    // Spawn edilecek nesnenin boyutlar�n� al
                    Renderer spawnRenderer = objectToSpawn.GetComponent<Renderer>();

                    if (spawnRenderer != null)
                    {
                        spawnPosition.y += spawnRenderer.bounds.extents.y; // Spawn edilecek nesnenin yar� y�ksekli�i
                    }

                    // Yeni nesneyi spawn eder.
                    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);


                }
            }
            
        }
        else
        {
            textMeshProUI.enabled = false;
        }

    }
}

