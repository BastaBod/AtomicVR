using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class AutoReturn : MonoBehaviour
{
    public Grabbable grab;
    public GameObject origin;
    public float timeOut;
    public float returnSpeed;



    private bool isOrigin;
    private float chrono;
    private bool grabbed;

    // Start is called before the first frame update
    void Start()
    {
        ResetPos();
        isOrigin = false;
        chrono = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.GrabPoints.Count >= 1)
            grabbed = true;

        if (grab.GrabPoints.Count < 1 && grabbed)
        {
            grabbed = false;
            isOrigin = false;
            chrono = timeOut;
        }

        if (!isOrigin)
        {
            chrono -= Time.deltaTime;
            if (chrono <= 0)
            {
                isOrigin = true;
                if (grabbed)
                    return;
                StartCoroutine(EaseInPos(transform.position, transform.rotation));
            }
        }

        

        if (Input.GetKeyDown("o"))
        {
            grabbed = false;
            isOrigin = false;
            chrono = timeOut;
        }
    }


    private void ResetPos()
    {
        //transform.parent.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.position = origin.transform.position;
        transform.rotation = origin.transform.rotation;
        isOrigin = true;
    }


    IEnumerator EaseInPos(Vector3 pos, Quaternion rot)
    {
        float t = 0;

        while(t < 1)
        {
            t += Time.deltaTime * returnSpeed;
            if (t > 1)
                t = 1;

            transform.position = Vector3.Lerp(pos, origin.transform.position, t);
            transform.rotation = Quaternion.Lerp(rot, origin.transform.rotation, t);
            yield return 0;
        }
        yield return null;
    }
}
