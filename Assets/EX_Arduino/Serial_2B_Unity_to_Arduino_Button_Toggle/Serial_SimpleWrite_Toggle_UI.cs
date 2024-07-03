using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Serial_SimpleWrite_Toggle_UI : MonoBehaviour
{
    int value = 0;

    public void OnClick_ToggleWrite()
    {
        value = 1 - value;
        string serialOut = value.ToString();
        GetComponent<Serial_SimpleWrite_Toggle>().SimpleWrite(serialOut);
    }
}
