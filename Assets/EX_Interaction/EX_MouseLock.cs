using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class EX_MouseLock : MonoBehaviour
{
    public Canvas canvas;
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;

    private void Start()
    {
        raycaster = canvas.GetComponent<GraphicRaycaster>();
        pointerEventData = new PointerEventData(null);
    }

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
            //if (EventSystem.current.IsPointerOverGameObject()) {
            //    print("EventSystem.current.IsPointerOverGameObject()");
            //    //return;
            //}
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit))
            //{
            //    print("hit.collider:" + hit.collider.name);
            //}
            //Cursor.lockState = CursorLockMode.None;
            ////Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true;
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);
            if (results.Count > 0)
            {
                foreach (RaycastResult result in results)
                {
                    print(result.gameObject);
                    if(result.gameObject.GetComponent<Button>() != null)
                    {
                        OnClick_DoSomething();
                    }
                }                
            }
        }
    }

    public void OnClick_DoSomething()
    {
        print("click");
    }
}
