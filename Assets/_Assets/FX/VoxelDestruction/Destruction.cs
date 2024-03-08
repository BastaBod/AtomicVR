using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject mesh;

    float cubeWidth;
    float cubeHeight;
    float cubeDepth;

    public float cubeScale = 0.3f;

    void Start()
    {
        cubeWidth = transform.localScale.z;
        cubeHeight = transform.localScale.y;
        cubeDepth = transform.localScale.x;

        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        CreateCube();

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

        // Make sure the target still exists before attempting to destroy it
        if (target != null)
        {
            // Destroy the target GameObject
            Destroy(target);
        }
    }

    void CreateCube()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
       // this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        if (gameObject.CompareTag("box"))
        {
            for (float x = 0; x < cubeWidth; x += cubeScale)
            {
                for (float y = 0; y < cubeHeight; y += cubeScale)
                {
                    for (float z = 0; z < cubeDepth; z += cubeScale)
                    {
                        Vector3 vec = transform.position;

                        GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
                        cubes.gameObject.GetComponent<MeshRenderer>().materials = gameObject.GetComponent<MeshRenderer>().materials;
                        cubes.transform.SetParent(this.gameObject.transform);
                    }
                }
            }
        }
    }
}

   
