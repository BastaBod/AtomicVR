using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class OVRThrow : MonoBehaviour
{

    public Grabbable grab;
    public Rigidbody rb;
    private bool grabbed;
    private Vector3 angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.GrabPoints.Count >= 1)
        {
            grabbed = true;
        }
            

        if (grab.GrabPoints.Count < 1 && grabbed)
        {
            rb.velocity = new Vector3(0, 0, 0);
            grab.enabled = false;
            grabbed = false;
            rb.AddForce(transform.forward * 500);
        }
    }
}
