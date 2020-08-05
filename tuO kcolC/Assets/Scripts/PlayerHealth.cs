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
        playerHP = 100;
    }

    private void Update()
    {
        healthText.text = "Health: " + playerHP;
    }
}