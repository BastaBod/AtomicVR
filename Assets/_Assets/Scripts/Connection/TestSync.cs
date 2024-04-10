using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class TestSync : MonoBehaviour
{

    public UnityEvent falconConnected, falconCanDraw, falconOccupied;
    public UnityEvent<Vector3> falconCursorPos;
    public UnityEvent ReInitFalcon, Received1, Received2, Received3, MiniGameStart;
    public UnityEvent<int> GiveItem1, GiveItem2, GiveItem3, GiveItem4, GiveItem5;


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
                int x, y;
                if (msg.Split(';').Length != 3)
                {
                    Debug.Log("wrong message");
                    return;
                }
                if (int.TryParse(msg.Split(';')[1], out x) && int.TryParse(msg.Split(';')[2], out y))
                {
                    falconCursorPos.Invoke(new Vector3(x,y*2, -1));
                    Debug.Log("Cursor goes to x : " + new Vector3(x,y, 0));
                }
                break;

                //...

            case 10: // pc falcon libre
                //dire au falcon de reinit
                ReInitFalcon.Invoke();
                break;
            case 11: // pc receive file_01
                Received1.Invoke();
                break;
            case 12: // pc receive file_02
                Received2.Invoke();
                break;
            case 13: // pc receive file_03
                Received3.Invoke();
                break;
            case 14: // pc start minigame
                MiniGameStart.Invoke();
                break;



            case 21: // pc receive item 1
                GiveItem1.Invoke(0);
                break;
            case 22: // pc receive item 2
                GiveItem2.Invoke(1);
                break;
            case 23: // pc receive item 3
                GiveItem3.Invoke(2);
                break;
            case 24: // pc receive item 4
                GiveItem4.Invoke(3);
                break;
            case 25: // pc receive item 5
                GiveItem5.Invoke(4);
                break;
        }
    }
}
