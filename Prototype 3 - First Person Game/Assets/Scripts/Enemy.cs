using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    // Enemy Stats
    public int curHp, maxHp, scoreToGive6;
    //Movement
    public float moveSpeed, attackRange, yPathOffset;
    // Coordinates for a path
    private List<Vector3> path;
    // Enemy Weapon 
    private Weapon weapon;
    // Target to follow
    private GameObject target;

    void Start()
    {
        // Get the Component
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
    }
    void UpdatePath()
    {
        //Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }
    
    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
        //Move Towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }
    void Update()
    
}
