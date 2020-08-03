using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    float deleteTimer = 0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up / 5;
        deleteTimer += Time.deltaTime;
        if (deleteTimer > 5.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerHealth.playerHP -= 20;
            Debug.Log("Player HP: " + PlayerHealth.playerHP);
        }
        Destroy(gameObject);
    }
}
