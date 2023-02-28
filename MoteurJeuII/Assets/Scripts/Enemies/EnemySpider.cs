using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : Enemies
{

    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float attackSpeed = 4f;
    [SerializeField] private float fieldOfView = 90f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float patrolRadius = 10f;

    private Transform player;
    private Vector3 startingPosition;
    private Animator spiderAnimator;

    private bool isAttacking = false;

    void Start()
    {
        // Initialize HP and lootDropChance
        HP = 100;
        lootDropChance = 0.2f;
        // Get reference to player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Save starting position
        startingPosition = transform.position;

        spiderAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttacking)
        {
            Attack();
        }
        else
        {
            // Check if player is in field of view
            Vector3 direction = player.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if (angle < fieldOfView * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, patrolRadius))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log(" Spider see PLayer");
                        StartCoroutine(ChasePlayer());
                        return;
                    }
                }
            }
            // If player is not in field of view, randomly walk around
            Walk();
        }
    }

    IEnumerator ChasePlayer()
    {
        isAttacking = true;
        while (true)
        {
            Vector3 direction = player.position - transform.position;
            float distance = direction.magnitude;
            spiderAnimator.SetBool("isWalking", true);
            if (distance < attackRange)
            {
                Attack();
                break;
            }
            transform.position = Vector3.MoveTowards(transform.position, player.position, attackSpeed * Time.deltaTime);
            yield return null;
        }
        isAttacking = false;
    }

    void Walk()
    {
        
    }

    void Attack()
    {
        spiderAnimator.SetTrigger("Attack");

        /*PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(10);
        }
            */

    }
}



