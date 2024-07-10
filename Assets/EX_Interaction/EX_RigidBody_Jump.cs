using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EX_RigidBody_Jump : MonoBehaviour
{
    public float jumpHeight = 5f;
    public float playerHeight = 1f;
    public Rigidbody body;
    public CapsuleCollider capsuleCollider;
    bool isGrounded;

    void Start()
    {
        if (body == null)
        {
            gameObject.AddComponent<Rigidbody>();
            body = GetComponent<Rigidbody>();
            body.freezeRotation = true;
            body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

        if (capsuleCollider == null)
        {
            gameObject.AddComponent<CapsuleCollider>();
            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        print($"collider height:{capsuleCollider.height}");
    }

    void Update()
    {
        bool isGrounded = CheckGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    bool CheckGrounded()
    {
        isGrounded = false;

        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity);
        float distToGround = capsuleCollider.height - capsuleCollider.center.y;
        if (hit.distance <= distToGround * 1.1f / 2f)
        {
            isGrounded = true;
        }
        //print($"grounded:{isGrounded} {hit.distance} \t{distToGround}");
        return isGrounded;
    }

    void Jump()
    {
        print("JUMP");
        body.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
