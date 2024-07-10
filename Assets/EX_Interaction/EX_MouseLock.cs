using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_MouseLock : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //if (Cursor.lockState == CursorLockMode.None)
            //{
            //    //Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.lockState = CursorLockMode.Confined;
            //    Cursor.visible = false;
            //}
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //if (Cursor.lockState == CursorLockMode.None)
            //{
            //    //Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.lockState = CursorLockMode.Confined;
            //    Cursor.visible = false;
            //}
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
