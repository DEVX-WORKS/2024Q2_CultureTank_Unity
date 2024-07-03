using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serial_SimpleWrite_UI : MonoBehaviour
{    public void OnClick_Write(string value)
    {
        Serial_SimpleWrite Serial = GetComponent<Serial_SimpleWrite>();
        Serial.SimpleWrite(value);
    }
}
