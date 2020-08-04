using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHazardCollision : MonoBehaviour
{
    Vector3 spawnPos;

    private void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Grinder")
            transform.position = spawnPos;
            
    }
}
