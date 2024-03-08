using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class AutoReturn : MonoBehaviour
{
    public Grabbable me;
    public GameObject origin;
    public float timeOut;

    private bool isOrigin;
    private float chrono;
    private bool grabbed;

    // Start is called before the first frame update
    void Start()
    {
        ResetPos();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isOrigin)
        {
            chrono -= Time.deltaTime;
            if (chrono < 0)
                ResetPos();
        }

        //if (Vector3.Distance(transform.position, origin.transform.position) > 1)
        //    ResetPos();

        if (me.GrabPoints.Count >= 1)
        {
            grabbed = true;
        }

        if (me.GrabPoints.Count < 1 && grabbed)
        {
            grabbed = false;
            isOrigin = false;
            chrono = timeOut;
        }
    }


    private void ResetPos()
    {
        //transform.parent.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.parent.position = origin.transform.position;
        transform.parent.rotation = origin.transform.rotation;
        isOrigin = true;
    }
}
