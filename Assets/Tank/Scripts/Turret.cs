using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Destructable
{
    [SerializeField] Transform barrel;
    [SerializeField] GameObject rocket;

    float torque;
    float force;

    Rigidbody rb;

    public string tagName;
    public float maxDist;
    public float maxAngle;

    int count = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        List<GameObject> gameObjects = new List<GameObject>();

        //get all colliders inside sphere
        var colliders = Physics.OverlapSphere(transform.position, maxDist);
        foreach (var collider in colliders)
        {
            //do not include ouselves
            if (collider.gameObject == gameObject) continue;
            //check for matching tag
            if (collider.tag == tagName)
            {
                //check if within max angle range
                Vector3 direction = collider.transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);

                if (angle <= maxAngle)
                {
                    //add game object to result
                    gameObjects.Add(collider.gameObject);
                }
            }
        }

        foreach (var go in gameObjects)
        {
            Debug.DrawLine(transform.position, go.transform.position, Color.magenta);

            if(go.tag == tagName)
            {
                transform.LookAt(go.transform.position);
            }
        }
    }

    // Runs at 50 fps, so no need for Delta Time
    private void FixedUpdate()
    {
        count++;
        if(count == 100)
        {
            Instantiate(rocket, barrel.position + Vector3.up, transform.rotation);
            count = 0;
        }
    }
}