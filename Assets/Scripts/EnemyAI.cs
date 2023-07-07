using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //patrol
    public Vector3 walkPoint;
    public bool walkPointset;
    public float walkPointRange;

    //attack
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private Animation animator;

    public float normalSpeed = 1f;
    public float runSpeed = 11f;
    public int randAttack;

    public PlayerStats health;

    public AudioSource source;
    public AudioClip clip;
    
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animation>();

    }
 

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); //check if player is in sight range sphere
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer); //check if player is in attack range sphere

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    void Patroling()
    {
        agent.speed = normalSpeed;
        animator.Play("Walk");

        if (!walkPointset) SearchWalkPoint();
        if (walkPointset)
        {
            agent.SetDestination(walkPoint);
            Vector3 dir = walkPoint - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 2).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }



        Vector3 distanceToWalkPoint = transform.position - walkPoint;


        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
            walkPointset = false;
    }

    void SearchWalkPoint()
    {
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        //check if random point is reachable
        NavMeshPath navpath = new NavMeshPath();
        Vector3 newpos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        NavMesh.CalculatePath(transform.position, newpos, -1, navpath);
        if (navpath.status == NavMeshPathStatus.PathComplete)
        {
            //Debug.Log(randomX + " " + randomZ);
            walkPoint = newpos;

            //if (Physics.Raycast(walkPoint, -transform.up, whatIsGround)) //check if the point is on the ground layer
            walkPointset = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Wall"))
        {
            SearchWalkPoint();
            Debug.Log("sss");
        }
    }

    void ChasePlayer()
    {

        NavMeshPath navpath = new NavMeshPath();
       
        NavMesh.CalculatePath(transform.position, player.transform.position, -1, navpath);
        //if (navpath.status == NavMeshPathStatus.PathComplete)
        {
            agent.speed = runSpeed;
            animator.Play("Run");
            agent.destination = player.transform.position;

        }

    }

    void AttackPlayer()
    {

        agent.SetDestination(transform.position);

        Vector3 dir = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 2).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (!alreadyAttacked)
        {
            //attack code
            randAttack = Random.Range(1, 3);

            
            animator.Play("Attack" + randAttack);
            source.PlayOneShot(clip);
           
            health.UpdateHealthBar(-10 * randAttack);
           
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

   
    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}