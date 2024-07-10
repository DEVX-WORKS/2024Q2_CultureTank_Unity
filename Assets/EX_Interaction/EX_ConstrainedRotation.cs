using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_ConstrainedRotation : MonoBehaviour
{
    public Transform ObjectToConstrainRotation;

    float rotationSpeed = 5f, XRotation, YRotation;

    [SerializeField]
    float RotationHorizontalLimit = 60f;

    [SerializeField]
    float RotationUpLimit = 60f;

    [SerializeField]
    float RotationDownLimit = 60f;

    void Update()
    {
        ConstrainRotation();
    }

    void ConstrainRotation()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        // XRotation --> up~down
        XRotation -= YaxisRotation;
        XRotation = Mathf.Clamp(XRotation, -RotationUpLimit, RotationDownLimit);
        // YRotation --> left~right
        YRotation += XaxisRotation;
        YRotation = Mathf.Clamp(YRotation, -RotationHorizontalLimit, RotationHorizontalLimit);
        //print($"XRot: {XRotation}, YRot: {YRotation}");
        ObjectToConstrainRotation.transform.localRotation = Quaternion.Euler(XRotation, YRotation, 0f);
    }
}
