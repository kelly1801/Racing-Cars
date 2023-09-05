using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private float moveSpeed = 15f;
    private Rigidbody obstacleRigidbody;

    private void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        obstacleRigidbody.velocity = Vector3.back * moveSpeed;

    }


}