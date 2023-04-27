using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject spawnAnim;

    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float projectileSpeed = 10f; // The speed at which the projectile is launched

    public Transform instantiatePos;

    public Animator spellBookAnim;

    public void Start()
    {
        instantiatePos = GameObject.Find("SpellBook").GetComponent<Transform>();
    }

    public void Update()
    {
        /*
        if(GameManager.instance.canCast == true)
        {
            // Check if the left mouse button was clicked
            //if (Input.GetMouseButtonUp(0))
            //{
                spellBookAnim.SetTrigger("Fire");

                // Get the mouse position in world space
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;

                // Calculate the direction in which to launch the projectile
                Vector3 launchDirection = (mousePosition - instantiatePos.position).normalized;

                // Instantiate the projectile prefab
                GameObject projectile = Instantiate(projectilePrefab, instantiatePos.position, Quaternion.identity);

                // Set the velocity of the projectile
                projectile.GetComponent<Rigidbody2D>().velocity = launchDirection * projectileSpeed;

                SpawnAnimationPlay();
            //}
        }
        */

    }

    public void CastSpell()
    {
        if (GameManager.instance.canCast == true)
        {
            // Check if the left mouse button was clicked
            //if (Input.GetMouseButtonUp(0))
            //{
            spellBookAnim.SetTrigger("Fire");

            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate the direction in which to launch the projectile
            Vector3 launchDirection = (mousePosition - instantiatePos.position).normalized;

            // Instantiate the projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, instantiatePos.position, Quaternion.identity);

            // Set the velocity of the projectile
            projectile.GetComponent<Rigidbody2D>().velocity = launchDirection * projectileSpeed;

            //SpawnAnimationPlay();
            //}
        }
    }

    public void SpawnAnimationPlay()
    {
        GameObject a = spawnAnim;
        Instantiate(a, instantiatePos.position, Quaternion.identity);
    }
}
