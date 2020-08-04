using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSignature : MonoBehaviour
{
    bool isRewinding = false;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

    public float recordTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
            StopRewind();
    }

    void Record()
    {
        if(pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        if(gameObject.GetComponent<Rigidbody>().IsSleeping() == false)
            pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
