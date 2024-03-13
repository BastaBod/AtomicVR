using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamagie : MonoBehaviour
{




    [Header("1 - connect falcon")]
    [Header("2 - disconnect falcon")]

    [Header("*********************")]
    [Header("4 - receive 1")]
    [Header("5 - receive 2")]
    [Header("6 - receive 3")]


    [Header("*********************")]
    [Header("y - receive directory")]
    [Header("u - receive disk")]
    [Header("i - receive diskette")]
    [Header("o - receive shield")]
    [Header("p - receive cursor")]

    public bool activateCheatKeys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activateCheatKeys)
            return;


        if (Input.GetKeyDown("1"))
            SynchronizeManager.RaiseSyncRequest("2");//connect falcon

        if (Input.GetKeyDown("2"))
            SynchronizeManager.RaiseSyncRequest("3");//disconnect falcon


        if (Input.GetKeyDown("4"))
            SynchronizeManager.RaiseSyncRequest("11");//receive 1
        if (Input.GetKeyDown("5"))
            SynchronizeManager.RaiseSyncRequest("12");//receive 2
        if (Input.GetKeyDown("6"))
            SynchronizeManager.RaiseSyncRequest("13");//receive 3

        if (Input.GetKeyDown("y"))
            SynchronizeManager.RaiseSyncRequest("21");//receive directory
        if (Input.GetKeyDown("u"))
            SynchronizeManager.RaiseSyncRequest("22");//receive disk
        if (Input.GetKeyDown("i"))
            SynchronizeManager.RaiseSyncRequest("23");//receive diskette
        if (Input.GetKeyDown("o"))
            SynchronizeManager.RaiseSyncRequest("24");//receive shield
        if (Input.GetKeyDown("p"))
            SynchronizeManager.RaiseSyncRequest("25");//receive cursor
    }
}
