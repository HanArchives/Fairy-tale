using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockbackForce = 10f; // The force with which to knock back the enemy
    public float knockbackDuration = 0.5f; // The duration of the knockback effect

    public Rigidbody2D rb; // Reference to the enemy's Rigidbody2D component
    private float knockbackTimer; // Timer for the knockback effect

    public void Start()
    {
        // Get a reference to the enemy's Rigidbody2D component
        //rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        // If the knockback timer is greater than zero, apply knockback force to the enemy
        if (knockbackTimer > 0f)
        {
            //rb.velocity = -transform.right * knockbackForce;
            rb.velocity = -GameManager.instance.player.transform.position * knockbackForce;
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
