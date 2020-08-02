using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDiff = Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.x));
        float zDiff = Mathf.Abs(Mathf.Abs(transform.position.z) - Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.z));
        if (xDiff < 0.7 && zDiff < 0.7)
        {
            SceneManager.LoadScene(1);
        }
    }
}
