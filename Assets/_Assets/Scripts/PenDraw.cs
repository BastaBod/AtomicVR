using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenDraw : MonoBehaviour
{
    public Transform rayOrigin;

    private bool isDrawing;
    private ScribbleSurface scrib;
    private float refresh;

    // Start is called before the first frame update
    void Start()
    {
        isDrawing = false;
    }

    // Update is called once per frame
    void Update()
    {

        refresh -= Time.deltaTime;

        if(isDrawing && scrib != null && refresh<0)
        {
            refresh = 0.1f;

            RaycastHit hit;
            //Debug.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward*0.05f, Color.red, 1f, false);
            if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, 0.05f, 1 << 6))
            {
                scrib.Inscribe(hit.point);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (scrib = other.gameObject.GetComponent<ScribbleSurface>())
        {
            isDrawing = true;
            scrib.StartDraw();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (scrib = other.gameObject.GetComponent<ScribbleSurface>())
        {
            isDrawing = false;
            scrib.PauseDraw();
        }
    }
}
