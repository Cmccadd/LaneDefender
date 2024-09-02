using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Default speed, can be adjusted per enemy type

    void Update()
    {
        // Move the enemy forward
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}

