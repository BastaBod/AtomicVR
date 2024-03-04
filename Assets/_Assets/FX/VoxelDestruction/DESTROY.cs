using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROY : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            PasStart();
        }
    }
    public void PasStart()
    {
        gameObject.BroadcastMessage("AutoDestroy", Camera.main.transform.forward);
    }
}
