using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private bool isLeft = true;

    void Update()
    {
        if(transform.position.z < 25)
        {
            if(transform.position.x > -5 && isLeft)
            {
                transform.Translate(Vector3.left * 2 * Time.deltaTime);

            }
            else
            {
                isLeft = false;
            }

            if (transform.position.x < 5 && !isLeft)
            {
                transform.Translate(Vector3.right * 2 * Time.deltaTime);

            }
            else
            {
                isLeft = true;
            }
        }   
    }
}
