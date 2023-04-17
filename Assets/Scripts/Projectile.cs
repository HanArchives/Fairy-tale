using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(GameManager.instance.player.horizontalInput * (GameManager.instance.player.movementSpeed * 10f), GameManager.instance.player.verticalInput * (GameManager.instance.player.movementSpeed * 10f), 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
