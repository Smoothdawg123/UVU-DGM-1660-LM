using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
public float attackCooldown;
public Transform firePoint;
public GameObject[] fireballs;
private Animator anim;
private PlayerController playerController;
private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }   

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerController.canAttack())
        Attack();
    
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        //pool fireball
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
                return i;

        }
        return 0;

    }
}
