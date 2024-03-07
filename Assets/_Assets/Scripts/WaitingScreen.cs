using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingScreen : MonoBehaviour
{
    public bool isHiding = true;
    public Material mat;


    public float showValue = 1000;
    public float hideValue = -1000;
    public float showPerS = 1000;

    // Start is called before the first frame update
    void Start()
    {
       // rend = GetComponent<Renderer>();

        mat = GetComponent<Image>().material;

        // Use the Specular shader on the material
       // rend.material.shader = Shader.Find("Specular");

      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            Debug.Log("isginding");
            isHiding = true;
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            Debug.Log("not hiding");
            isHiding = false;

        }

        if (isHiding)
        {
            float _CutOffHeight = mat.GetFloat("_CutOffHeight");
            if (_CutOffHeight > hideValue)
            {
                _CutOffHeight -= showPerS * Time.deltaTime;
                mat.SetFloat("_CutOffHeight", _CutOffHeight);
            }
        }
        else
        {
            float _CutOffHeight = mat.GetFloat("_CutOffHeight");
            if (_CutOffHeight < showValue)
            {
                _CutOffHeight += showPerS * Time.deltaTime;
                mat.SetFloat("_CutOffHeight", _CutOffHeight);
            }
          
        }
    }

    public void HideScreen()
    {
        isHiding = true;
    }
    public void DisplayScreen()
    {
        isHiding = false;
    }
}
