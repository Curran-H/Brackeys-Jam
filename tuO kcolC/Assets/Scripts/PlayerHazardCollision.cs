using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHazardCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
            PlayerHealth.playerHP = 0;
    }
}