using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2.0f;
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = .2f;
    public LayerMask groundMask; //nelerle etkileþime girileceðini tutacak layer ekleyip Ground objesine de bu layerý atamayý  UNUTMA!!!
    bool isGrounded;

    bool isCrouching;
    public Transform PlayerCamera;

    public CameraShake cameraShake; // Reference to the CameraShake script
    //private CameraFOV cameraFOV; // Reference to the CameraFOV script
    //GameObject cameraManager = GameObject.Find("CameraManager");

    private void Start()
    {
        
        //cameraShake = cameraManager.GetComponent<CameraShake>();
        //cameraFOV = PlayerCamera.GetComponent<CameraFOV>();
        
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//char controller kullandýðýmýz için ayrýca fizik fonksiyonlarýnda manuel olarak yararlanmalýyýz collision için falan

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        /*transform.position += new Vector3(moveHorizontal*speed*Time.deltaTime, 0.0f, moveVertical*speed*Time.deltaTime); BU kod satýrý ile global koordinatlara göre hareket
         saðlanýyor yani W ile her zaman +x yönünde hareket olur. Bu new Vector3 kýsmýndan dolayý böyle???
        */
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        controller.Move(movement * speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.LeftShift))//Crouching SADECE KAMERA HAREKET EDÝYO KARAKTER HAREKETÝ ÝÇÝN ADJUSTMENT LAZIM
        {
            speed = 0.5f; // Hýzý azalt
            //controller.height = 1.5f;
            isCrouching = true;
            //controller.center = new Vector3(0, -0.5f, 0); // Merkezi ayarla

            PlayerCamera.localPosition = new Vector3(0, -0.4f, 0); // Kamerayý eðilme pozisyonuna getir
            transform.position += Vector3.down * (2f - 1.5f) / 2; // Move player down
        }
        else if (Input.GetKey(KeyCode.LeftControl))//Sprint
        {
            speed = 10f;

            if (cameraShake != null)
            {
                cameraShake.StartShaking(); // Titremeyi baþlat
            }
        }
        else
        {
            //controller.height = 2f;
            speed = 5f;
            isCrouching = false;
            //controller.center = new Vector3(0, 0, 0);
            PlayerCamera.localPosition = new Vector3(0, 0.6677045f, 0);
            transform.position += Vector3.up * (2f - 1.5f) / 2;
            if (cameraShake != null)
            {
                cameraShake.StopShaking(); // Titremeyi durdur
            }
        }


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //isGrounded konulmayýnca sonsuz jump devam edebiliyo
            {

                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity

            }
            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime); // Apply vertical velocity
                                                        //Bu kýsýmdaki sýkýntý velcoity her zýplamadan sonra durmadan artmaya devam ediyor o yüzden yere deðdiðinde sýfýrlamak lazým bunun için groundcheck kullanýlýyor

        }
    }

