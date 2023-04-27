using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool isCloseRange;
    public bool isLongRange;

    public float projectileSpeed;
    public float destroyTime;

    public float destroyTimer;
    public bool willBeDestroyed;

    public GameObject smokeObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isLongRange)
        {
            //rb.AddForce(new Vector3(GameManager.instance.player.horizontalInput * (GameManager.instance.player.movementSpeed * projectileSpeed), GameManager.instance.player.verticalInput * (GameManager.instance.player.movementSpeed * projectileSpeed), 1f));
            //rb.AddForce(new Vector3(GameManager.instance.wand.wandPosition.transform.position.x * (GameManager.instance.player.movementSpeed * projectileSpeed), GameManager.instance.wand.wandPosition.transform.position.y * (GameManager.instance.player.movementSpeed * projectileSpeed), 1f));
        }

        if (isCloseRange)
        {
            //rb.AddForce(new Vector3(GameManager.instance.player.horizontalInput * (GameManager.instance.player.movementSpeed * projectileSpeed), GameManager.instance.player.verticalInput * (GameManager.instance.player.movementSpeed * projectileSpeed), 1f));
            //rb.AddForce(new Vector3(GameManager.instance.wand.wandPosition.transform.position.x * (GameManager.instance.player.movementSpeed * projectileSpeed), GameManager.instance.wand.wandPosition.transform.position.y * (GameManager.instance.player.movementSpeed * projectileSpeed), 1f));
            DestroyObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (willBeDestroyed == true)
        {
            destroyTimer += Time.deltaTime;

            if (destroyTimer >= destroyTime)
            {
                Destroy(gameObject);
                GameObject a = smokeObject;
                Instantiate(a, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        GameObject a = smokeObject;
        Instantiate(a, transform.position, Quaternion.identity);
    }

    public void DestroyObject()
    {
        willBeDestroyed = true;
    }
}
