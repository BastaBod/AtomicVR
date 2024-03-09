using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelDestroy : MonoBehaviour
{
    public GameObject mesh;
    [Range(2,5)]
    public int subdivLevel = 2;
    private float scaling;

    float cubeWidth;
    float cubeHeight;
    float cubeDepth;

    public float cubeScale = 0.3f;

    void Start()
    {
        scaling = 1 / (float)subdivLevel;

        cubeWidth = transform.localScale.z;
        cubeHeight = transform.localScale.y;
        cubeDepth = transform.localScale.x;

        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        //CreateCube();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }


    public void AutoDestroy(Vector3 explosionPoint)
    {

        for (int i = gameObject.transform.childCount-1; i>=0;i--)
        {
            GameObject obj = gameObject.transform.GetChild(i).gameObject;
            if (obj.GetComponent<Rigidbody>() == null)
            {
                obj.GetComponent<MeshRenderer>().enabled = true;
                obj.gameObject.AddComponent<Rigidbody>();
                obj.GetComponent<Rigidbody>().mass = 500;
                obj.GetComponent<Rigidbody>().isKinematic = false;
                obj.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 5;
                obj.GetComponent<Rigidbody>().AddExplosionForce(15, explosionPoint, 0.3f, 1, ForceMode.Impulse);
                obj.GetComponent<Transform>().SetParent(null);
                StartCoroutine(DestroyAfterDelay(obj.gameObject, 2));
            }
        }
    }


    private IEnumerator DestroyAfterDelay(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (target != null)
        {
            // Destroy the target GameObject
            Destroy(target);
        }
    }

    void CreateCube(PixelMonster monster)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        // this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        subdivLevel = monster.GetSubdivLevel();
        scaling = 1 / (float)subdivLevel;

        if (gameObject.CompareTag("box"))
        {
            for (float x = 0; x < subdivLevel; x ++)
            {
                for (float y = 0; y < subdivLevel; y ++)
                {
                    for (float z = 0; z < subdivLevel; z ++)
                    {
                        GameObject cubes = (GameObject)Instantiate(mesh, transform.position, Quaternion.identity);
                        cubes.transform.SetParent(this.gameObject.transform);
                        cubes.transform.localScale = new Vector3(scaling, scaling, scaling);
                        cubes.transform.localPosition = -0.5f * transform.localScale + 0.5f * new Vector3(scaling, scaling, scaling) + new Vector3(x, y, z) * scaling;
                    }
                }
            }
        }
    }
}

   
