using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed, jumpForce;      //movement speed in units per second   //force applied upwards

    public float lookSensitivity;            // Mouse look sensitivity

    public float maxLookX;                  // lowest down we can look

    public float minLookX;                  // Highest up we can look

    private float rotX;                     // Current x rotation of the camera

    private Camera camera;

    private Rigidbody rb;

    private float Vector3;

    void Start()
    {
        //Get Components
        camera = camera.main;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
        Move();
    }

    void Move()
    {

        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new vector3(x, rb.velocity.y, z);

    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX -= rotX + Input.GetAxis("Mouse Y") * lookSensitivity;
        
        
    }


}
