﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    #region Variables

    public float pressLength; //The distance that makes a press valid
    public string interactionTarget;
    bool pressed; //

    Vector3 startPos; //Starting Y
    Rigidbody rb; //

    GameObject target;
    public AudioClip buttonClick;
    public AudioSource aSource;
    #endregion

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

        target = GameObject.Find(interactionTarget);
    }

    void Update()
    {
        float distance = Mathf.Abs(transform.position.y - startPos.y); //Check for travelled distance

        if (distance >= pressLength)
        {
            if (!pressed)
                OnButtonDownInteraction();
        }  //Detect the button downs

        if (distance <= pressLength)
        {
            if (pressed)
            {
                OnButtonUpInteraction();
            }
        }  //Detect the button ups

        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }  //Prevent the button's Y value from exceeding a maximum (Fixing elastic appearance unbefitting of a button)
    }

    public void OnButtonDownInteraction()
    {
        Debug.Log("Pressed!");
        if (target != null)
            target.SetActive(false);
        pressed = true;
        if (aSource.isPlaying == false && pressed == true)
            aSource.PlayOneShot(aSource.clip);
    } //

    public void OnButtonUpInteraction()
    {
        Debug.Log("Unpressed.");
        if(target != null)
            target.SetActive(true);
        pressed = false;
        if (aSource.isPlaying == false && pressed == false)
            aSource.PlayOneShot(aSource.clip);
    } //

}
