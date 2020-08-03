//Huge thanks and credit to Swindle Creative
//https://www.youtube.com/watch?v=DzO270DH0tk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    #region Variables
    public Transform camera;
    public Rigidbody rb;

    #region CameraVariables
    public float rotationSmoothSpeed = 10f;
    public float camRotationSpeed    = 5f;
    public float cameraMinimumY      = -90f;
    public float cameraMaximumY      = 90f;
#endregion

    #region MovementVariables
    public float walkSpeed   = 9f;
    public float runSpeed    = 14f;
    public float maxSpeed    = 20f;
    public float jumpPower   = 30f;
    #endregion

    #region Gravity
    public float extraGravity = 45f;
    #endregion

    #region Directions and Rotations
    float    bodyRotationX;
    float    camRotationY;
    Vector3  directionIntentX;
    Vector3  directionIntentY;
    float    speed;
    #endregion

    public bool grounded;
    #endregion

    void Update()
    {
        LookRotation();
        Movement();
        ExtraGravity();
        GroundCheck();
        if(grounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    void LookRotation()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //Get Camera and body rotational values
        bodyRotationX    += Input.GetAxis("Mouse X") * camRotationSpeed;
        camRotationY     += Input.GetAxis("Mouse Y") * camRotationSpeed;

        //Stop our Camera from rotating 360 degrees
        camRotationY = Mathf.Clamp(camRotationY, cameraMinimumY, cameraMaximumY);

        //Create rotation targets and handle rotations of the body and camera
        Quaternion camTargetRotation     = Quaternion.Euler(-camRotationY, 0, 0);
        Quaternion bodyTargetRotation    = Quaternion.Euler(0, bodyRotationX, 0);

        //Handle rotations
        transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRotation, Time.deltaTime * rotationSmoothSpeed);

        camera.localRotation = Quaternion.Lerp(camera.localRotation, camTargetRotation, Time.deltaTime * rotationSmoothSpeed);
    }

    void Movement()
    {
        //Direction must match camera direction
        directionIntentX = camera.right;
        directionIntentX.y = 0;
        directionIntentX.Normalize();

        directionIntentY = camera.forward;
        directionIntentY.y = 0;
        directionIntentY.Normalize();

        //Change our characters velocity in this direction
        rb.velocity = directionIntentY * Input.GetAxis("Vertical") * speed + directionIntentX * Input.GetAxis("Horizontal") * speed + Vector3.up * rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        //Control our speed based on our movement state
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
    }

    void ExtraGravity()
    {
        rb.AddForce(Vector3.down * extraGravity);
    }

    void GroundCheck()
    {
        RaycastHit groundHit;
        grounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 1.25f);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
