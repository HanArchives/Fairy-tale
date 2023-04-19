using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public GameObject thisEnemy;
    public BoxCollider2D thisEnemyColl;

    public float enemyMaxHealth;
    public float enemyCurrentHealth;

    //public Weapon weapon;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth; // Makes sure the enemy is at full HP when spawning
        //weapon = GameObject.Find("Hammer").GetComponent<Weapon>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon" || other.tag == "PlayerProjectile") // Checks if the weapon hits the enemy's hitbox
            enemyCurrentHealth = (enemyCurrentHealth - 1f); // Calculates the amount of damage done

        if (enemyCurrentHealth <= 0) // Checks if the enemy is killed
        {
            Destroy(thisEnemy); // Destroys the enemy
            Destroy(gameObject); // Destroys the hitbox GameObject

        }
        else // What happens when the enemy isn't killed, but is hit
        {
            //enemyCurrentHealth -= weapon.weaponDamage; // Calculates the amount of damage done
        }
    }
}