using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static float gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 10)
        {
            gameTimer += Time.deltaTime;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gameTimer = 0f;
        }
    }
}
