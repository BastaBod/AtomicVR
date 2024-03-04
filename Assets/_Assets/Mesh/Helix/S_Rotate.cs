using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Rotate : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 350f;

 

    void Start()
    {
    
    }

    void Update()
    {
        // Rotate object around its up axis
        transform.Rotate(new Vector3(1,0,0), -rotationSpeed * Time.deltaTime);

      
    }
}
