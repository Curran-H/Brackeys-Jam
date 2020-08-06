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
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward / 2;
        deleteTimer += Time.deltaTime;
        if (deleteTimer > 5.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && InvincibleFrames.isInvincible == false)
        {
            PlayerHealth.playerHP -= 25;
            Debug.Log("Player HP: " + PlayerHealth.playerHP);
        }
        else if (collision.collider.tag == "IsInfestible")
            Debug.Log("Bullet hit enemy!");
        Destroy(gameObject);
    }
}
