using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Player Controller Awake");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide with " + collision.gameObject.name);
    }
}
