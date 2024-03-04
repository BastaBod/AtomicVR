using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class TestSync : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI feedbackText;

    public UnityEvent ReconnectedFalcon;
    public UnityEvent f1, f2, f3, f4, f5;


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
            case 1:
                ReconnectedFalcon.Invoke();
                if (feedbackText)
                    feedbackText.text = "Connection etablished";
                break;
            case 2: //start draw
                f2.Invoke();
                break;
            case 3: //draw
                int x, z;
                if (msg.Split(';').Length != 3)
                    return;
                break;
            case 4: // pause draw
                f2.Invoke();
                break;
            case 5: // end
                f3.Invoke();
                break;
            case 14:
                f4.Invoke();
                break;
            case 15:
                f5.Invoke();
                break;
        }
    }
}
