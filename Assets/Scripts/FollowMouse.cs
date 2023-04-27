using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;
    public float minRadius;
    public float speed = 1f;

    public float distanceFromOrigin;
    public float maxRadius;
    public float maxDistanceX;
    public float maxDistanceY;
    public float maxDistanceZ;

    public Vector3 offset;

    public Vector3 mousePosition;

    void Start()
    {
        //offset = transform.localPosition - player.position;
        //offset = transform.localPosition;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        float angle = Time.deltaTime * speed;

            //offset = mousePosition - new Vector3(maxDistanceX, maxDistanceY, maxDistanceZ);

            //Vector3 targetPosition = player.position + new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
            Vector3 targetPosition = (player.position) + ((mousePosition) * (radius));
            //transform.position = targetPosition + offset;
            transform.position = targetPosition + offset;



    }
}