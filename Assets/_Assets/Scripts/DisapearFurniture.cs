using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisapearFurniture : MonoBehaviour
{
    public float speed;
    public GameObject[] objToDisapear;

    public float min, max;
    public UnityEvent Lancerlecombat;


    private List<Material> toDisapear;

    private float height = 0; // -> 5

    public bool isHiding;


    // Start is called before the first frame update
    void Start()
    {/*
        foreach (GameObject go in objToDisapear)
        {
            if(go.GetComponent<Renderer>() != null)
            {
                if(go.GetComponent<Renderer>().material != null)
                    toDisapear.Add(go.GetComponent<Renderer>().material);
            }
        }*/
        height = min;
    }

    // Update is called once per frame
    void Update()
    {
        if(height < max && isHiding)
        {
            height += Time.deltaTime * speed;
            foreach (GameObject go in objToDisapear)
            {
                if (go.GetComponent<Renderer>() != null)
                {
                    if(go.GetComponent<Renderer>().materials.Length > 0)
                    {
                        foreach(Material m in go.GetComponent<Renderer>().materials)
                            m.SetFloat("_CutOffHeight", height);
                    }
                }
            }

            if (height >= max)
            {
                foreach (GameObject go in objToDisapear)
                    go.SetActive(false);
                Lancerlecombat.Invoke();
                this.enabled = false;
            }
        }
    }

    public void SetHiding(bool b)
    {
        isHiding = b;
    }

}
