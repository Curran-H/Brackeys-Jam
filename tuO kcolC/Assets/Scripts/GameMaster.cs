using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private AudioManager audioManager;

    //When adding sounds, put "public static [descriptor]SoundName;" (e.g. respawnSoundName) here, and audioManager.PlaySound("[descriptor]SoundName") under the corresponding function

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        if(audioManager == null)
        {
            Debug.LogError("[ERROR] No AudioManager found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth.playerHP <= 0)
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
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RemoveHost()
    {

    }
}