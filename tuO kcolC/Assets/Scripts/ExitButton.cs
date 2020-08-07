using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Button startButton;

    // Update is called once per frame
    void Update()
    {
        startButton.onClick.AddListener(exitGame);
    }

    void exitGame()
    {
        Application.Quit();
    }
}
