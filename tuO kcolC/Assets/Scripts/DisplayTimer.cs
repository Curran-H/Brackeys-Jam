using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour
{
    Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        var timerObj = (GameObject)GameObject.FindWithTag("TimerText");
        timerObj.GetComponent<TMPro.TextMeshProUGUI>().text = "You took " + Mathf.Round(GameTimer.gameTimer * 100f) / 100f + " seconds to \"clock out.\"";
    }
}
