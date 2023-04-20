using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigid; // Rigidbody2D of the enemy
    public GameObject player;
    public float speed; // Movespeed of the enemy

    private Vector3 playerposition;
    private Vector3 enemyposition;

    private float enemyYposition;
    private float enemyXposition;

    public float distance; // Distance between player and enemy
    public float followDistance;

    public float damageToGive = 1; // Amount of damage the enemy does

    public GameObject enemyUI;

    void Start()
    {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); // Calculating the distance between the enemy and the player
        Vector2 direction = player.transform.position - transform.position; // Calculating which direction the enemy needs to move in (towards the player)

        float step = speed * Time.deltaTime; // Calculates the movespeed of the enemy when following the player
        float step2 = 0f * Time.deltaTime; // Calculates the movespeed of the enemy when not following the player

        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, 0); // Makes sure the enemy only tracks the player's position on the X-axis
        enemyposition = new Vector3(rigid.transform.position.x, rigid.transform.position.y, 0); // Makes sure the enemy can move

        // Makes the enemy follow or not follow the player
        if (distance < followDistance) // If the player comes close enough to the enemy
        {
            rigid.transform.position = Vector3.MoveTowards(enemyposition, playerposition, step); // The enemy will move towards the player
        }
        if (distance > followDistance) // If the player is out of range of the enemy
        {
            rigid.transform.position = Vector3.MoveTowards(enemyposition, playerposition, step2); // The enemy will stop moving
        }

        //Makes the enemy always look at where the player is
        if (player.transform.position.x > enemyXposition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0); // Resets sprite direction
            enemyUI.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (player.transform.position.x < enemyXposition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0); // Resets sprite direction
            enemyUI.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //GameManager.instance.OnHitpointChange(); // Function for the HP bar to change when taking a hit

            Vector3 hitDirection = col.transform.position - transform.position; // Calculates the pushback direction of the player when taking a hit
            hitDirection = hitDirection.normalized;
            //FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection); // Function for the player to take damage

            GameManager.instance.playerHealth -= damageToGive;
        }
    }
}