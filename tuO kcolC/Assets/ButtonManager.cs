using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public float pressLength; //The distance that makes a press valid
    public bool pressed; //

    Vector3 startPos; //Starting Y
    Rigidbody rb; //

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Mathf.Abs(transform.position.y - startPos.y); //Check for travelled distance

        if (distance >= pressLength)
        {
            if (!pressed)
            {
                pressed = true;

                //Input your function call here
                Debug.Log("Pressed!");
            }
            else
            {
                pressed = false;
            }
        }  //Detect the button ups and downs

        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }  //Prevent the button's Y value from exceeding a maximum (Fixing elastic appearance unbefitting of a button)
    }
}
