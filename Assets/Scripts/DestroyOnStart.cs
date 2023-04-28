using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnStart : MonoBehaviour
{

    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
        SoundManager.PlaySound("enemyDeathSound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
