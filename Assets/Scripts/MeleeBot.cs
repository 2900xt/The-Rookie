using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeBot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask ground, playerMask;
    //patrolling
    public Vector3 walkPoint;
    bool walkSet;
    public float walkPointRange;
    public Animator anim;
    public EntityData data;

    //attacking
    public float timeBtwnAttacks;
    bool alrdyAttacked;
    public Transform shootPoint;
    public GameObject projectile;
    public GameObject destroyEffect;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) Attack();

        if(data.HP <= 0)
        {
            Dead();
        }
    }

    private void Patroling()
    {
        if(!walkSet) searchWalkPoint();

        if(walkSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
    }

    private void searchWalkPoint()
    {
        float randX = Random.Range(-walkPointRange, walkPointRange);
        float randZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(randX, transform.position.y, randZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, ground))
        {
            walkSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alrdyAttacked)
        {
            anim.SetTrigger("Shoot");
            Instantiate(projectile, shootPoint.position, shootPoint.rotation);

            alrdyAttacked = true;
            Invoke(nameof(ResetAttack), timeBtwnAttacks);
        }  
    }

    private void ResetAttack()
    {
        alrdyAttacked = false;
    }

    public void Dead()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
