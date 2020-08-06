using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleFrames : MonoBehaviour
{
    float invTimer = 0f;
    public static bool isInvincible;

    private void Start()
    {
        isInvincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(invTimer < 0.5f)
            invTimer += Time.deltaTime;
        else if(isInvincible)
            isInvincible = false;
    }
}
