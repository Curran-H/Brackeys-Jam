using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Vent collision detected!");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "IsPickupable" || other.gameObject.tag == "IsInfestible")
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<CharControl>().inVent = true;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            Debug.Log("Vent collision tag detection successful!");
            other.gameObject.transform.position += gameObject.transform.up * 0.2f;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharControl>().inVent = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
