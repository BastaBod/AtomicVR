using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class Throwabble : MonoBehaviour
{

    public float veloMin, throwForce, spinForce;
    public TouchHandGrabInteractable grab;
    public TouchHandGrabInteractor handl, handr;

    public bool isHoming;


    private Rigidbody rb;

    private bool isThrown;

    private GameObject target;

    private float max = 0;
    private bool isGrabbed;


    private Vector3 velo, previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isThrown = false;
        isGrabbed = false;
        velo = new Vector3(0,0,0);
        previousPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        velo = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

        if (max < velo.magnitude)
            max = velo.magnitude;

        Debug.Log("velomax : "+max);

        Debug.Log("++ " + (!grab.HasSelectingInteractor(handl) && !grab.HasSelectingInteractor(handr)));
        isGrabbed = grab.HasSelectingInteractor(handl) || grab.HasSelectingInteractor(handr);
        //if (!grab.HasSelectingInteractor(handl) && !grab.HasSelectingInteractor(handr))
            //return;

        //Debug.Log("nice = " + max);
        Debug.Log("velo = " +velo.magnitude*60 +" / "+ veloMin);

        if (!isThrown && velo.magnitude >= veloMin)
        {
            
            if (!isGrabbed)
                return;
            
            Debug.Log("nice");

            transform.GetChild(0).gameObject.SetActive(false);

            if (isHoming)
            {
                if (AquireTarget())
                {
                    isThrown = true;
                    return;
                }
            }
            Vector3 direction = velo.normalized;
            gameObject.layer = LayerMask.NameToLayer("Weapons");
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(throwForce * direction);
            isThrown = true;
        }

        if(isThrown && target!= null)
        {
            rb.AddTorque(transform.up * spinForce);
            //homing behaviour
        }
    }

    public void BeginGrab()
    {
        isGrabbed = true;
    }

    public void EndGrab()
    {
        isGrabbed = false;
    }


    private bool AquireTarget()
    {
        //target = ;
        return true;
    }
}
