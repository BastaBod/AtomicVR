using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArc : MonoBehaviour
{
    public GameObject[] objectPool;
    private int currentIndex = 0;
    float elapsedTime = 0f; // Counts up to repeatTime
    public float repeatTime = 3f; // Time taken to repeat in second
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in objectPool)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= repeatTime)
        {
            // Do something here
            NewRandomObject();
            // Subtract repeat time
            elapsedTime -= repeatTime;
        }
    }

    public void NewRandomObject()
    {
        int newIndex = Random.Range(0, objectPool.Length);
        if (currentIndex  != newIndex) { 
        // Deactivate old gameobject
        objectPool[currentIndex].SetActive(false);
        // Activate new gameobject
        currentIndex = newIndex;
        objectPool[currentIndex].SetActive(true);
        }
    }
}
