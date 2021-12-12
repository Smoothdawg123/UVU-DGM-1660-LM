using UnityEngine;

public class Enemy_UpAndDown : MonoBehaviour
{
    public float movementDistance;
    public float speed;
    public float damage;
    public float height;
    private bool movingUp;
    private Vector3 pos;

    private void Awake()
    {
        pos = transform.position;
    }

    private void Update()
    {

        Vector3 offset = (movingUp == true ? new Vector3(0, height / 2, 0) : new Vector3(0, -height / 2, 0));

        transform.position = Vector3.MoveTowards(transform.position, pos + offset, speed * Time.deltaTime);

        if(transform.position == pos + offset)
            movingUp = !movingUp;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}