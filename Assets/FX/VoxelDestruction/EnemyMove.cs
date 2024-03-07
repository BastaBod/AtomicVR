using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed);
    }
}
