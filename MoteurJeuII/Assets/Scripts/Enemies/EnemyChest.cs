using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChest : Enemies
{
    public float chaseSpeed = 5f;
    public float attackDamage = 20f;
    private Transform player;

    void Start()
    {
        // Initialize HP and lootDropChance
        HP = 100;
        lootDropChance = 0.75f;
        // Get reference to player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    public void OnInteract()
    {
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (true)
        {
            float fixedSpeed = chaseSpeed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, fixedSpeed);
            yield return new WaitForFixedUpdate();
        }
    }

    public void Attack()
    {


    }
}
