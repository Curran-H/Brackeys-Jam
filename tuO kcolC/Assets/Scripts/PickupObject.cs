using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Camera cam;
    public float interactDist;

    public Transform holdPos;
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

        if (Input.GetKeyDown(KeyCode.E) && hasObject)
        {
            DropObject();
        }

        if(hasObject)
        {
            if(CheckDist() >= 1f)
            {
                MoveObjToPos();
            }
        }
    }


    private void CalculateRotVector()
    {
        float x = Random.Range(-0.5f, 0.5f);
        float y = Random.Range(-0.5f, 0.5f);
        float z = Random.Range(-0.5f, 0.5f);

        rotateVector = new Vector3(x, y, z);
    }

    public float CheckDist()
    {
        float dist = Vector3.Distance(objectIHave.transform.position, holdPos.transform.position);
        return dist;
    }

    private void MoveObjToPos()
    {
        objectIHave.transform.position = Vector3.Lerp(objectIHave.transform.position, holdPos.position, attractSpeed * Time.deltaTime);
    }

    private void DropObject()
    {
        objectRB.constraints = RigidbodyConstraints.None;
        objectIHave.transform.parent = null;
        objectIHave = null;
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
                objectIHave.transform.SetParent(holdPos);

                objectRB = objectIHave.GetComponent<Rigidbody>();
                objectRB.constraints = RigidbodyConstraints.FreezeAll;

                hasObject = true;

                CalculateRotVector();
            }
        }
    }
}
