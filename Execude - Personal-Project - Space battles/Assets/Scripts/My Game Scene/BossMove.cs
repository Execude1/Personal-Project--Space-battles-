using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] private bool isLeft = true;
    private Rigidbody bossRb;

    private void Start()
    {
        bossRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.position.z < 25)
        {
            if (transform.position.x >= -5 && isLeft)
            {
                bossRb.velocity += Vector3.left * Time.deltaTime;
            }

            if (transform.position.x <= -5 && isLeft)
            {
                isLeft = false;
                bossRb.velocity = (-1) * Vector3.zero;
            }

            if (transform.position.x <= 5 && !isLeft)
            {
                bossRb.velocity += Vector3.right * Time.deltaTime;
            }

            if(transform.position.x >= 5 && !isLeft)
            {
                isLeft = true;
                bossRb.velocity = (-1) * Vector3.zero;
            }
        }
    }
}
