using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;
    public GameObject hitParticle;

    void OnEnable()
    {
        shootTime = Time.time;
    }
    //If Hit deal damage to the Player/Enemy
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerControls>().TakeDamage(damage);
        else if (other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
        // Disable Projectile for future use
        gameObject.SetActive(false);
        //Create the hit particle
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);
        
    }
    
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}
