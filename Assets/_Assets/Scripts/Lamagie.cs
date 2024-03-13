using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamagie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
            SynchronizeManager.RaiseSyncRequest("2");//connect falcon

        if (Input.GetKeyDown("2"))
            SynchronizeManager.RaiseSyncRequest("3");//disconnect falcon


        if (Input.GetKeyDown("4"))
            SynchronizeManager.RaiseSyncRequest("11");//receive 1
        if (Input.GetKeyDown("5"))
            SynchronizeManager.RaiseSyncRequest("12");//receive 1
        if (Input.GetKeyDown("6"))
            SynchronizeManager.RaiseSyncRequest("13");//receive 1
    }
}
