using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private AudioManager audioManager;

    float infestTimer = 20f;
    public bool hasHost;
    public GameObject player;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (PlayerHealth.playerHP <= 0)
            {
                PlayerHealth.playerHP = 0;
                //if(host is found)
                //{
                RemoveHost();
                //}
                //else
                //{
                GameOver();
                //}
            }

            if (hasHost)
            {
                if (infestTimer < 20f)
                    infestTimer += Time.deltaTime;
                else if (infestTimer > 20f)
                    infestTimer = 20f;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RemoveHost()
    {

    }

    public void InfestHost()
    {

    }
}