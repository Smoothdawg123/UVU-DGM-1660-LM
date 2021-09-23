using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Destroy enemy if the collider hitting the trigger has the tag projectile
      if(collider.CompareTag("Projectile"))
          Destroy(gameObject);
    }






}
