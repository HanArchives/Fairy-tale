using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float healAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(GameManager.instance.playerHealth != GameManager.instance.playerMaxHealth)
            {
                GameManager.instance.playerHealth += healAmount;
                SoundManager.PlaySound("healSound");
                Destroy(gameObject);
            }

            if (GameManager.instance.playerHealth == GameManager.instance.playerMaxHealth)
            {
                GameManager.instance.playerHealth = GameManager.instance.playerMaxHealth;
            }
        }

    }

}
