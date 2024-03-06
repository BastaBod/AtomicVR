using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class TestSync : MonoBehaviour
{

    public UnityEvent falconConnected, falconCanDraw, falconOccupied, falconCursorPos;
    public UnityEvent pcConnected, Received1, Received2;


    private void OnEnable()
    {
        SynchronizeManager.OnSyncRequest += ProcessCode;
    }

    private void OnDisable()
    {
        SynchronizeManager.OnSyncRequest -= ProcessCode;
    }

    public void ProcessCode(string msg)
    {
        int code;
        if (!int.TryParse(msg.Split(';')[0], out code))
            return;

        switch (code)
        {
            case 1: // falcon connected
                falconConnected.Invoke();
                break;
            case 2: // falcon ready to draw
                falconCanDraw.Invoke();
                break;
            case 3: // falcon occupied
                falconOccupied.Invoke();
                break;
            case 4: // falcon current cursor position
                falconCursorPos.Invoke();
                break;

                //...

            case 10: // pc connected
                pcConnected.Invoke();
                break;
            case 11: // pc receive file_01
                Received1.Invoke();
                break;
            case 12: // pc receive file_02
                Received2.Invoke();
                break;
        }
    }
}
