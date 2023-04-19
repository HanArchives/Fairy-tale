using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public Transform wandPosition;
    public Transform thisWandPosition;
    public Rigidbody2D rb;

    public float wandMoveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //BOVEN, RECHTS, LINKS, BENEDEN
        if (GameManager.instance.player.horizontalInput == 1)
        {
            wandPosition.transform.localPosition = new Vector3(1, 0, 0);
        }

        if (GameManager.instance.player.horizontalInput == -1)
        {
            wandPosition.transform.localPosition = new Vector3(1, 0, 0);
        }

        if (GameManager.instance.player.verticalInput == 1)
        {
            wandPosition.transform.localPosition = new Vector3(0, 1, 0);
        }

        if (GameManager.instance.player.verticalInput == -1)
        {
            wandPosition.transform.localPosition = new Vector3(0, -1, 0);
        }

        //SCHUIN
        if (GameManager.instance.player.horizontalInput == 1 && GameManager.instance.player.verticalInput == 1)
        {
            wandPosition.transform.localPosition = new Vector3(1, 1, 0);
        }

        if (GameManager.instance.player.horizontalInput == 1 && GameManager.instance.player.verticalInput == -1)
        {
            wandPosition.transform.localPosition = new Vector3(1, -1, 0);
        }

        if (GameManager.instance.player.horizontalInput == -1 && GameManager.instance.player.verticalInput == 1)
        {
            wandPosition.transform.localPosition = new Vector3(1, 1, 0);
        }

        if (GameManager.instance.player.horizontalInput == -1 && GameManager.instance.player.verticalInput == -1)
        {
            wandPosition.transform.localPosition = new Vector3(1, -1, 0);
        }
    }

    public void FixedUpdate()
    {
        //rb.velocity = new Vector3(GameManager.instance.player.horizontalInput * GameManager.instance.player.movementSpeed, GameManager.instance.player.verticalInput * GameManager.instance.player.movementSpeed);
    }
}
