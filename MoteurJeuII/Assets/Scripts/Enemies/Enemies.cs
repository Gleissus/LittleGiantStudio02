using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int HP;
    public float lootDropChance;

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            // enemy is defeated
            CheckLootDrop();
        }
    }
    public virtual void CheckLootDrop()
    {
        float randomValue = Random.value;
        if (randomValue <= lootDropChance)
        {
            // enemy drops loot
            // code to spawn loot
        }
    }

}
