using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    public Transform leftEdge;
    public Transform rightedge;
    [Header("Enemy")]
    public Transform enemy;
    [Header("Movement parameters")]
    public float speed;
    private Vector3 initScale;
    private bool movingLeft;
    
    [Header("Idle Behavior")]
    public float idleDuration;
    private float idleTimer;
    

    [Header("Enemy Animator")]
    public Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);

    }
    // Left Edge and Right Edge. When Enemy hits the position he will change directions
    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightedge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
        
    }
    //Change Directions 
    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
        initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }
 
}
