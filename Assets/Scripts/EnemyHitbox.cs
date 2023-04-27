using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitbox : MonoBehaviour
{
    public Enemy enemy;
    public GameObject thisEnemy;
    public BoxCollider2D thisEnemyColl;
    public KnockBack knockBack;

    public float enemyMaxHealth;
    public float enemyCurrentHealth;

    public Text enemyHealthText;

    //public Weapon weapon;

    public bool isWizardEnemy;
    public GameObject dropPage;


    public GameObject destroyAnimation;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth; // Makes sure the enemy is at full HP when spawning
        //weapon = GameObject.Find("Hammer").GetComponent<Weapon>();
    }

    public void Update()
    {
        if(enemyCurrentHealth == enemyMaxHealth)
        {
            enemyHealthText.text = "";
        }

        if (enemyCurrentHealth != enemyMaxHealth)
        {
            enemyHealthText.text = enemyCurrentHealth + " / " + enemyMaxHealth;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerProjectile") // Checks if the weapon hits the enemy's hitbox
        {
            enemyCurrentHealth = (enemyCurrentHealth - GameManager.instance.spellDamage); // Calculates the amount of damage done
            
            knockBack.KnockbackEnemy();
            GameManager.instance.isBattling = true;

        }

        if (other.tag == "GroundLay") // Checks if the weapon hits the enemy's hitbox
        {
            enemyCurrentHealth = (enemyCurrentHealth - GameManager.instance.spellDamage); // Calculates the amount of damage done
            enemy.speed = 0.5f;
        }

        if (enemyCurrentHealth <= 0f) // Checks if the enemy is killed
        {
            Destroy(thisEnemy); // Destroys the enemy
            Destroy(gameObject); // Destroys the hitbox GameObject
            GameManager.instance.isBattling = false;
            GameObject b = destroyAnimation;
            Instantiate(b, transform.position, Quaternion.identity);

            if (isWizardEnemy)
            {
                GameObject a = dropPage;
                Instantiate(a, transform.position, Quaternion.identity);
            }

        }
        else // What happens when the enemy isn't killed, but is hit
        {
            //enemyCurrentHealth -= weapon.weaponDamage; // Calculates the amount of damage done
        }
    }
}