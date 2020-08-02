using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRigidBody;

    private Vector3 inputVector;
    public float speed;
    public float jumpPower;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, playerRigidBody.velocity.y, Input.GetAxisRaw("Vertical") * speed);
        playerRigidBody.velocity = inputVector;
        if (Input.GetButtonDown("Jump"))
        {
            playerRigidBody.AddForce(0, jumpPower, 0, ForceMode.Impulse);
            Debug.Log("Jump Success");
        }
    }
}
