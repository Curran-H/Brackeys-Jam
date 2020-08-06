using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private AudioManager audioManager;

    public static bool hasHost;
    public GameObject player;
    public GameObject parasite;

    //When adding sounds, put "public static [descriptor]SoundName;" (e.g. respawnSoundName) here, and audioManager.PlaySound("[descriptor]SoundName") under the corresponding function

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("[ERROR] No AudioManager found in the scene!");
        }
        Cursor.visible = false;

        player = GameObject.FindGameObjectWithTag("Player");

        if (player.name == "Bean")
        {
            hasHost = true;
            InvincibleFrames.isInvincible = false;
        }
        else if (player.name == "Parasite")
            hasHost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.playerHP <= 0)
        {
            PlayerHealth.playerHP = 0;
            if(hasHost)
            {
                RemoveHost();
            }
            else
            {
                GameOver();
            }
        }
        else
            player = GameObject.FindGameObjectWithTag("Player");

        if (DeathTimer.deathTimer <= 0f)
            GameOver();

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RemoveHost()
    {
        PlayerHealth.playerHP = 25;
        hasHost = false;
        Instantiate(parasite, player.transform.position - new Vector3(0f, 0.5f, 0f), player.transform.rotation);
        if(player.GetComponent<RewindObject>().initialColor != Color.clear)
        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Player"))
        {
            ObjectFound.GetComponent<RewindObject>().initialColor = player.GetComponent<RewindObject>().initialColor;
        }
        foreach (GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(ObjectFound.name == "Bean")
                Destroy(ObjectFound);
        }
        Destroy(player);
    }
}