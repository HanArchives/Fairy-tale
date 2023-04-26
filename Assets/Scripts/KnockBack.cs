using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockbackForce = 10f; // The force with which to knock back the enemy
    public float knockbackDuration = 0.5f; // The duration of the knockback effect

    public Rigidbody2D rb; // Reference to the enemy's Rigidbody2D component
    private float knockbackTimer; // Timer for the knockback effect

    public Enemy enemy;

    public Vector3 playerPosition;
    public Vector3 enemyPosition;

    public Vector3 newPosition;

    public float newPositionX;
    public float newPositionY;

    public void Start()
    {
        // Get a reference to the enemy's Rigidbody2D component
        //rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        playerPosition = enemy.playerposition;
        enemyPosition = enemy.enemyposition;

        if (enemy.player.transform.position.x > enemy.enemyXposition)
        {
            //newPosition = (-playerPosition - new Vector3(1, 0, 0));
            newPositionX = enemy.enemyposition.x - 1;
        }

        if (enemy.player.transform.position.x < enemy.enemyXposition)
        {
            //newPosition = (playerPosition - new Vector3(1, 0, 0));
            newPositionX = enemy.enemyposition.x + 1;
        }

        if (enemy.player.transform.position.y > enemy.enemyYposition)
        {
            //newPosition = (-playerPosition - new Vector3(0, 1, 0));
            newPositionY = enemy.enemyposition.y - 1;
        }

        if (enemy.player.transform.position.y < enemy.enemyYposition)
        {
            //newPosition = (playerPosition - new Vector3(0, 1, 0));
            newPositionY = enemy.enemyposition.y + 1;
        }
    }

    public void FixedUpdate()
    {
        // If the knockback timer is greater than zero, apply knockback force to the enemy
        if (knockbackTimer > 0f)
        {
            //rb.velocity = -transform.right * knockbackForce;
            //rb.velocity = -GameManager.instance.player.transform.position * knockbackForce;

            float step = knockbackForce * Time.deltaTime; // Calculates the movespeed of the enemy when following the player
            rb.transform.position = Vector3.MoveTowards(enemyPosition, new Vector3(newPositionX, newPositionY, 0), knockbackForce); // The enemy will move towards the player


            //rb.velocity = new Vector2(-rb.transform.position.x, -rb.transform.position.y * (knockbackForce * Time.deltaTime));

            knockbackTimer -= Time.deltaTime;
        }
        // Otherwise, stop applying knockback force
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void KnockbackEnemy()
    {
        // Set the knockback timer to the duration of the knockback effect
        knockbackTimer = knockbackDuration;
    }
}
