
using UnityEngine;

public class FatRatAI : MonoBehaviour
{
    // state
    enum State { Patrol, Follow }
    private State currentState = State.Patrol;
    Animator animator;

    [Header("States")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float reachPPointDistace = 0.3f;
    [SerializeField] private float reachPlayerDistace = 1f;
    [SerializeField] private float infectDistance = 2f;
    [SerializeField] private float stateChangeDistance = 3f;

    [Header("Attack")]
    [SerializeField] float damageCooldown = 1f;
    float lastDamageTime = 1f;
    [SerializeField] float damageAmount = 10f;

    [Header("Infect")]
    [SerializeField] float infectionCooldown = 0.1f;
    float lastInfectTime = -Mathf.Infinity;
    [SerializeField] float infectAmount = .1f;

    private int currentPatrolIndex = 0;
    private Transform player;


    // refs
    Rigidbody2D rb;
    PlayerHealth playerHealth;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                HandlePatrol();
                break;
            case State.Follow:
                HandleFollow();
                break;
        }
    }

    private void HandlePatrol()
    {
        // direction to patrolPoint
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        // move to patrolPoint
        rb.linearVelocity = patrolSpeed * direction;
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        // if reached a patrolPoint, target the next one in patrolPoints[]
        if (Vector2.Distance(transform.position, targetPoint.position) <= reachPPointDistace)
        {
            currentPatrolIndex = Random.Range(0, patrolPoints.Length);
        }

        // if player is near, switch state
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < stateChangeDistance)
        {

            currentState = State.Follow;
            
        }


    }
    private void HandleFollow()
    {

        // get direction to player
        Vector2 direction = (player.position - transform.position).normalized;

        // move to player
        rb.linearVelocity = patrolSpeed * direction;
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);


        // stop if reached player
        if (Vector2.Distance(transform.position, player.position) <= reachPlayerDistace)
        {
            rb.linearVelocity = Vector2.zero;
            CheckDamageCoolown();

        }


        // if player is too far, switch state
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer >= stateChangeDistance)
        {

            currentState = State.Patrol;
            

        }

        if (distanceToPlayer < infectDistance)
        {
            InfectPlayer();
        }
    }

    public void CheckDamageCoolown()
    {
        rb.linearVelocity = Vector2.zero;
        // check, if damageColdown-time has passed
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            AttackPlayer();
            lastDamageTime = Time.time;
        }
    }

    public void AttackPlayer()
    {
        playerHealth.TakeDamage(damageAmount);
    }



    public void InfectPlayer()
    {
        if (Time.time - lastInfectTime >= infectionCooldown)
        {
            playerHealth.IncreaseInfection(infectAmount);
        }
        

    }
    

}
