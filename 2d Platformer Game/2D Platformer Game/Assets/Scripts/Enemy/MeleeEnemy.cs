
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{   
    [Header("Attack Parameters")]
    public float attackCooldown;
    public int damage;
    public float range;
    
    [Header("Collider Parameters")]

    public float colliderDistance;
    public BoxCollider2D boxCollider;

    [Header("Player Layer")]
    public LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Attack Sound")]
    public AudioClip attackSound;   


    //References from scripts and animations
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown && playerHealth.currentHealth > 0)
            {
                //Attack
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
                SoundManager.instance.PlaySound(attackSound);
            }

        }
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x *range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
        0, Vector2.left, 0, playerLayer);
        

        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }
    // visual bounds on collider for enemy range of attack
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x *range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    //Enemy will damage if in sight of player and within it's collider range
    private void DamagePlayer()
    {
        //If player is still in range damage player
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
