using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float shootTimer = 0.0f;
    public float shootTime = 3.0f;
    public GameObject gun;
    public GameObject bullet;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = null;
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootTime)
            {
                shootTimer -= shootTime;
                RaycastHit hit;
                var rayDirection = player.transform.position - transform.position;
                if (Physics.Linecast(transform.position, player.transform.position, out hit) && hit.collider.transform == player.transform)
                    Instantiate(bullet, gun.transform.position + (transform.forward * 1f), default);
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
                player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
