using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        // ����������� ���� �������� ��������� �� ������� ������� (������ - Field)
        if(collision.gameObject.name == "Field")
        {
            Destroy(gameObject);
        }
    }
}
