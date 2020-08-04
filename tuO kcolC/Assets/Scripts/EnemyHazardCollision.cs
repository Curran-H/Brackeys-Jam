using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHazardCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Grinder")
            Destroy(gameObject);
    }
}