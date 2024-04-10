using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSwitch : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> frElems, enElems;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ShowEn()
    {
        foreach (GameObject go in enElems)
            go.SetActive(true);
    }

    public void HideEn()
    {
        foreach (GameObject go in enElems)
            go.SetActive(false);
    }
}
