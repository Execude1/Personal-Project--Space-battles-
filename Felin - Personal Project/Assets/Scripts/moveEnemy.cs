using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    private float speed = 3000.0f;
    private float zDestroy = -20.0f;
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);

        //if(transform.position.z < zDestroy)
        //{
        //    Destroy(gameObject);
        //}
    }
}
