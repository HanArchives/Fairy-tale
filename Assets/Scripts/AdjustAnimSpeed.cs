using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustAnimSpeed : MonoBehaviour
{
    private Animator anim;
    public float animationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = animationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
