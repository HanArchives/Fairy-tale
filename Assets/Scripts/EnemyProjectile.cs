using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed = 1f; // Movement speed of the projectile
    public float destroyTime; // Time before the projectile is destroyed
    public int damageToGive = 1; // Amount of damage the projectile does
    public int enemyMaxHealth = 1;
    public int enemyCurrentHealth = 1;

    Rigidbody2D rb;

    Player target;
    Vector2 moveDirection;

    private Vector3 arrowSize; // Size of the projectile

    public GameObject smokeObject;

    public Vector3 targetPos;

    public float startTime;

    protected void Start()
    {
        startTime += Time.deltaTime;

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();

        arrowSize = transform.localScale;
        Destroy(gameObject, destroyTime); // Makes sure the projectile is destroyed after the destroyTime passes

        targetPos = target.transform.position;

        SoundManager.PlaySound("spellSound");

    }

    private void Update()
    {
        if(startTime >= destroyTime)
        {
            GameObject a = smokeObject;
            Instantiate(a, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        rb.transform.position = Vector2.MoveTowards(rb.transform.position, targetPos, moveSpeed * Time.deltaTime); // Makes the projectile move towards the player

        // Swaps direction of the projectile sprite based on the direction it's shooting
        if (moveDirection.x > 0)
            transform.localScale = arrowSize;
        else if (moveDirection.x < 0)
            transform.localScale = new Vector3(arrowSize.x * -1, arrowSize.y, arrowSize.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject a = smokeObject;
            Instantiate(a, transform.position, Quaternion.identity);
            Destroy(gameObject);

            SoundManager.PlaySound("playerHurtSound");
            GameManager.instance.player.anim.SetTrigger("Hurt");
            GameManager.instance.player.playerHealthAnim.SetTrigger("IsHit");

            GameManager.instance.playerHealth -= damageToGive;
        }

    }

}
