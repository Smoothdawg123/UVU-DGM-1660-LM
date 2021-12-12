using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public float healthValue;
    public AudioClip pickupSound;

    // Collectible for health and adds a specific amount to the total health
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
