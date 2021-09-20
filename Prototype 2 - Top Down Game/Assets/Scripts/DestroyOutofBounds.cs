using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    public float topBound = 4.95f;
    public float bottomBound = -4.85f;
    public float sideBound = 11.17f;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound){

         Destroy(gameObject);

        }

      if(transform.position.y < bottomBound){

       Destroy(gameObject);

       if(transform.position.x > sideBound){

        Destroy(gameObject);

       }

      }

    }
}
