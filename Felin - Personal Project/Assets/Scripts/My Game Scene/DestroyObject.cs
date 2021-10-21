using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        // уничтожение всех объектов выходящих за пределы границы (объект - Field)
        if(collision.gameObject.name == "Field")
        {
            Destroy(gameObject);
        }
    }
}
