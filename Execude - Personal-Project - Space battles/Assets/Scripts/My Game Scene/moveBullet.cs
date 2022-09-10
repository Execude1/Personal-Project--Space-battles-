using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    private Rigidbody bulletRb;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bulletRb.AddForce(Vector3.forward * 100);   // полет пули
    }
}
