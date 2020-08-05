using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfestEnemy : MonoBehaviour
{
    public Camera cam;
    public float interactDist;

    public GameObject infestTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            DoRay();
    }

    private void DoRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDist))
        {
            if (hit.collider.gameObject.CompareTag("IsInfestible"))
            {
                infestTarget = hit.collider.gameObject;
                Instantiate(gameObject, infestTarget.transform.position, infestTarget.transform.rotation);
                foreach(GameObject ObjectFound in GameObject.FindGameObjectsWithTag("Player"))
                {
                    ObjectFound.GetComponent<RewindObject>().initialColor = gameObject.GetComponent<RewindObject>().initialColor;
                }
                PlayerHealth.playerHP = 100;
                Destroy(infestTarget);
                Destroy(gameObject);
            }
        }
    }
}
