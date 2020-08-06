using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindObject : MonoBehaviour
{
    public Camera cam;
    public float interactDist;

    public GameObject objectSelected;
    public Color initialColor;

    // Start is called before the first frame update
    void Start()
    {
        initialColor = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            DoRay();
        if (objectSelected != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
                objectSelected.GetComponent<TimeSignature>().StartRewind();
            if (Input.GetKeyUp(KeyCode.G))
                objectSelected.GetComponent<TimeSignature>().StopRewind();
        }
    }

    private void DoRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDist))
        {
            if (objectSelected != null)
            {
                objectSelected.GetComponent<TimeSignature>().StopRewind();
                objectSelected.GetComponent<Renderer>().material.color = initialColor;
                objectSelected = null;
            }
            if (hit.collider.gameObject.GetComponent<TimeSignature>() != null)
            {
                objectSelected = hit.collider.gameObject;
                initialColor = objectSelected.GetComponent<Renderer>().material.color;
                objectSelected.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
