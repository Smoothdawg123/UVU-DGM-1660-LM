using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    //Traps deal damage when player hits them
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);
    }
}