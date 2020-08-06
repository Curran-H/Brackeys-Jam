using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    public static float deathTimer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        deathTimer = 20.00f;
    }

    private void Update()
    {
        if (GameMaster.hasHost && deathTimer < 20f)
            deathTimer += Time.deltaTime / 2f;
        else if (GameMaster.hasHost == false)
            deathTimer -= Time.deltaTime;
        else
            deathTimer = 20f;

        if(deathTimer >= 0)
            timerText.text = deathTimer.ToString("F2");
        else
            timerText.text = "GOODBYE";
    }
}
