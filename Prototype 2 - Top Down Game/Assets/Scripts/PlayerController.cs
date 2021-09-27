using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;

    public float turnSpeed = 20.0f;

    public float hInput;

    public float vInput; 

    public float xRange = 11.17f;

    public float yRange = 4.85f;

    public GameObject projectile; 

    public Transform launcher;

    public Vector3 offset = new Vector3(0,1,0);

     


    //public float health; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     hInput = Input.GetAxis("Horizontal");  
     vInput = Input.GetAxis("Vertical"); 

     transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
     transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
     // Create a wall on the -x side
     if(transform.position.x < -xRange)
     {
         transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

     }
  
  // Create a wall on x side
     if(transform.position.x > xRange)
     {
         transform.position = new Vector3( xRange, transform.position.y, transform.position.z);

     }


     if(transform.position.y < -yRange)
     {
         transform.position = new Vector3( -yRange, transform.position.y, transform.position.z);

     }

if(transform.position.y > yRange)
     {
         transform.position = new Vector3( yRange, transform.position.y, transform.position.z);

     }
      
     if (Input.GetButtonDown("Fire1"))
     {
        Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);


     } 



    }


}
