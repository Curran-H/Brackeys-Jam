using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform playerTransform;
    UnityEngine.AI.NavMeshAgent gameNavMesh;
    public float checkRate = 0.01f;
    float nextCheck;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        gameNavMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }

    }

    void FollowPlayer()
    {
        if (playerTransform != null)
        {
            gameNavMesh.transform.LookAt(playerTransform);
            gameNavMesh.destination = playerTransform.position;
        }
        else
        {
            if(GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
