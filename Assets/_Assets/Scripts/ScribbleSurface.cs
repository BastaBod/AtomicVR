using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScribbleSurface : MonoBehaviour
{
    public GameObject touchPoint;
    private bool isDrawing;

    // Start is called before the first frame update
    void Start()
    {
        isDrawing = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartDraw()
    {
        ClientManager.instance.SendTcpMessage("2;0;0");
        isDrawing = true;
    }

    public void PauseDraw()
    {
        ClientManager.instance.SendTcpMessage("4;0;0");
        isDrawing = false;
    }

    public void EndDraw()
    {
        ClientManager.instance.SendTcpMessage("5;0;0");
        isDrawing = false;
    }

    public void Inscribe(Vector3 pos)
    {
        touchPoint.transform.position = pos;
        Vector3 newpos = touchPoint.transform.localPosition;
        ClientManager.instance.SendTcpMessage("3;"+(int)(newpos.x*200)+";"+(int)(newpos.y*200));
        //Debug.Log("la pos du pen = " + touchPoint.transform.localPosition);
    }

    public Vector2 GetTouchPosNormalized()
    {
        return new Vector2 (touchPoint.transform.localPosition.x*2, touchPoint.transform.localPosition.y*2);
    }
}
