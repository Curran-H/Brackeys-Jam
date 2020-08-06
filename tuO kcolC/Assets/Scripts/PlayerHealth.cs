using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHP;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").name == "Bean")
            PlayerHealth.playerHP = 50;
        else if (GameObject.FindGameObjectWithTag("Player").name == "Parasite")
            PlayerHealth.playerHP = 25;
    }

    private void Update()
    {
        healthText.text = playerHP.ToString();
    }
}