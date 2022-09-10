using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOfBounds : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z < -50 || transform.position.z > 150)
        {
            Destroy(gameObject);
        }
    }
}
