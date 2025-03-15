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

        RaycastHit hit; // Gönderilecek ýþýnýn belirli layermasklere çarpýp çarpmayacaðý tutulur.

        int layerMask = LayerMask.GetMask("IntCube");

        //ray holds both the position and direction
        if (Physics.Raycast(ray, out hit, 6f, layerMask))
        {
            Debug.Log("Hit");
            textMeshProUI.enabled = true;//player can now see the text

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.CompareTag("ColorCube")) //.tranform da kullanýlabilirdi burdaki amaç GamObjecte ulaþmak çünkü
                {
                    // Çarpýþýlan objenin Renderer bileþenini al
                    Renderer renderer = hit.collider.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Rastgele bir renk oluþtur
                        Color randomColor = Random.ColorHSV();

                        // Objenin rengini deðiþtir
                        renderer.material.color = randomColor;

                        // Debug: Rastgele rengi konsola yazdýr
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
                    // Hedef nesnenin Renderer bileþenini al
                    Renderer targetRenderer = targetObject.GetComponent<Renderer>();

                    // Hedef nesnenin üstündeki pozisyonu hesapla
                    
                    spawnPosition.y += targetRenderer.bounds.extents.y; // Hedef nesnenin yarý yüksekliði

                    // Spawn edilecek nesnenin boyutlarýný al
                    Renderer spawnRenderer = objectToSpawn.GetComponent<Renderer>();

                    if (spawnRenderer != null)
                    {
                        spawnPosition.y += spawnRenderer.bounds.extents.y; // Spawn edilecek nesnenin yarý yüksekliði
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

