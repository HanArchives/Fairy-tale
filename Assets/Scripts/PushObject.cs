using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            GameManager.instance.isPushing = true;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameManager.instance.isPushing = false;
        }
    }
}
