using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum State { Patrol, Follow }
    private State currentState = State.Patrol;

    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float reachPPointDistace = 0.3f;
    [SerializeField] private float reachPlayerDistace = 1f;
    [SerializeField] private float stateChangeDistance = 3f
    ;

    Rigidbody2D rb;

    private int currentPatrolIndex = 0;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
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

        // stop if reached player
        if (Vector2.Distance(transform.position, player.position) <= reachPlayerDistace)
        {
            rb.linearVelocity = Vector2.zero;
        }


        // if player is too far, switch state
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer >= stateChangeDistance)
        {
            currentState = State.Patrol;
        }

        
    }
    

}
