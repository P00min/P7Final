using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public int damage = 1;
    public float attackCooldown = 1f;

    private Transform player;
    private PlayerHealth playerHealth;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        lastAttackTime = -attackCooldown;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            MoveTowardsPlayer();

            if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Add movement logic here (e.g., using NavMeshAgent)
        transform.LookAt(player);
        // Assuming NavMeshAgent is used
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.position);
    }

    void AttackPlayer()
    {
        lastAttackTime = Time.time;
        playerHealth.TakeDamage(damage);
    }
}