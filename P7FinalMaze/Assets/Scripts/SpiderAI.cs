using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiderAI : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float attackRadius = 2f;
    public float moveSpeed = 3.5f;
    public int damage = 1;
    public float attackCooldown = 2f;

    private float lastAttackTime;

    void Start()
    {
        lastAttackTime = -attackCooldown; // So that the spider can attack immediately if in range
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            MoveTowardsPlayer();
            if (distanceToPlayer <= attackRadius && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}