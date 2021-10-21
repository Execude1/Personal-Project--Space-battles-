using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float sizeBackground;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        sizeBackground = GetComponent<BoxCollider>().size.x * 2.1f; // получение размера "background" 
    }

    void Update()   // смещение background-а и возвращение на стартовую позицию
    {
        if (transform.position.z <= startPosition.z - sizeBackground)
        {
            transform.position = startPosition;
        }

        transform.Translate(0, 10f * Time.deltaTime, 0);
    }
}
