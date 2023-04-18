using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChest : Enemies
{
    private bool isInRange = false;
    private bool isAttacking = false;
    public float chaseSpeed = 5f;
    public float attackDamage = 20f;
    public float attackRange = 4;
    public float attackSpeed = 2;

    private Transform player;
    private Animator chestMonsterAnimator;
    

    void Start()
    {
        // Initialize HP and lootDropChance
        HP = 100;
        lootDropChance = 0.75f;
        // Get reference to player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        chestMonsterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is within range and presses the interact button (E key)
        {
            Debug.Log("Player Open Chest Monster");
            StartCoroutine(ChasePlayer());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player is in range");
            isInRange = true;
        }
    }

    public override void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            // enemy is defeated
            CheckLootDrop();
        }
    }

    IEnumerator ChasePlayer()
    {
        isAttacking = true;
        while (true)
        {
            Vector3 direction = player.position - transform.position;
            float distance = direction.magnitude;
            chestMonsterAnimator.SetBool("isWalking", true);
            if (distance < attackRange)
            {
                Attack();
                break;
            }
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
            transform.LookAt(player);
            yield return null;
        }
        isAttacking = false;
    }

    public void Attack()
    {
        chestMonsterAnimator.SetTrigger("Attack");
    }
}
