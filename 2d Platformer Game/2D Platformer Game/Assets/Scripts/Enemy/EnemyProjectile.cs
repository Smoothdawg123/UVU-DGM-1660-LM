
using UnityEngine;

public class EnemyProjectile : EnemyDamage //Will damage the player every time they touch 
{
    public float speed;
    public float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D collision;

    private bool hit;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        collision.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void EnemyDamage (Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); //Executes code from Enemy Damage script first 
        collision.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode"); //When the object is a fireball explode it
        else
            gameObject.SetActive(false); //When this hits any object deactivate arrow
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}