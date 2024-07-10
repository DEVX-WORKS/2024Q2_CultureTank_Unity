using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Transform_Rotate : MonoBehaviour
{
    public Transform ObjectToRotate;
    public float rotationSpeed = 5f;

    private void Start()
    {
        if (ObjectToRotate == null)
        {
            ObjectToRotate = transform;
        }
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ObjectToRotate.Rotate(Vector3.up, -rotationSpeed * 10 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            ObjectToRotate.Rotate(Vector3.up, rotationSpeed * 10 * Time.deltaTime);
        }
    }
}
