using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterSeconds : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyTime = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Object.Destroy(gameObject, destroyTime);

    }
}
