using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Camera cam;
    public float interactDist;

    public GameObject holdPos;
    private FixedJoint holdJoint;
    public float attractSpeed;

    public GameObject objectIHave;
    private Rigidbody objectRB;

    private Vector3 rotateVector = Vector3.one;

    private bool hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasObject)
        {
            DoRay();
        }
        else if (Input.GetMouseButtonDown(0) && hasObject)
        {
            DropObject();
        }
        
        if(hasObject)
        {
            if (CheckDist() >= 2.1f || (CheckDist() < 0.4f && Mathf.Abs(transform.position.y) - Mathf.Abs(objectIHave.transform.position.y) > 0.51))
            {
                DropObject();
            }
        }
    }

    public float CheckDist()
    {
        float dist = Vector3.Distance(objectIHave.transform.position, holdPos.transform.position);
        return dist;
    }

    public void DropObject()
    {
        holdPos.GetComponent<FixedJoint>().connectedBody.drag = 0f;
        holdPos.GetComponent<FixedJoint>().connectedBody.angularDrag = 0.05f;
        Destroy(holdPos.GetComponent<FixedJoint>());
        objectRB.useGravity = true;
        objectIHave = null;
        objectRB = null;
        hasObject = false;
    }

    private void DoRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist))
        {
            if (hit.collider.gameObject.CompareTag("IsPickupable"))
            {
                objectIHave = hit.collider.gameObject;
                objectRB = objectIHave.GetComponent<Rigidbody>();
                holdPos.AddComponent<FixedJoint>();
                holdPos.GetComponent<FixedJoint>().connectedBody = objectRB;
                holdPos.GetComponent<FixedJoint>().connectedAnchor = objectIHave.transform.position;
                holdPos.GetComponent<FixedJoint>().enableCollision = false;
                holdPos.GetComponent<FixedJoint>().anchor = holdPos.transform.position;
                objectRB.useGravity = false;
                hasObject = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objectIHave)
        {
            DropObject();
        }
    }
}
