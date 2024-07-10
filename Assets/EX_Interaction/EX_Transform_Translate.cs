using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Transform_Translate : MonoBehaviour
{
    public Transform ObjectToTranslate;
    public float translateSpeed = 3f;

    private void Start()
    {
        if (ObjectToTranslate == null)
        {
            ObjectToTranslate = transform;
        }
    }
    void Update()
    {
        Translate();
    }

    void Translate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ObjectToTranslate.Translate(Vector3.forward * translateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            ObjectToTranslate.Translate(-Vector3.forward * translateSpeed * Time.deltaTime);
        }
    }
}
