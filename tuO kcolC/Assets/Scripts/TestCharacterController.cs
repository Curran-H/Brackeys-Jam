using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Rigidbody playerRigidBody;

    private Vector3 inputVector;
    public float speed;
    public float jumpPower;
    public float gravity = -9.81f;
    #endregion

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        float y = Mathf.Sqrt(jumpPower * -2f * gravity);

        Vector3 move = (transform.right * xAxis) + (transform.forward * zAxis);
        playerRigidBody.velocity = move * speed; //Make it move

        //inputVector = new Vector3(xAxis * speed, playerRigidBody.velocity.y, zAxis * speed); //Get "where to move"
        //playerRigidBody.velocity = inputVector; //Make it move

        if (Input.GetButtonDown("Jump"))
        {
            //playerRigidBody.AddForce(0, jumpPower, 0, ForceMode.Impulse);
            playerRigidBody.AddForce(Vector3.up *jumpPower, ForceMode.Impulse);
            Debug.Log("Jumped");
        } //Jump
    }
}
