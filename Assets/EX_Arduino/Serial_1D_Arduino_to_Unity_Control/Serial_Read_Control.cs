using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 아래의 System.IO.Ports를 사용하기 위해서는
 * Unity Editor > Edit > Project Settings > Player > Other Settings > Configuration > Api Compatibility Level을
 * .NET 4.x로 설정하고 Unity Editor를 다시 시작해야 함 * 
 */
using System.IO.Ports;

using System; // catch exception 처리를 위해 사용

/*
Arduino Code
------------- 
int btn0 = 2, btn1 = 3;

void setup() {
  Serial.begin(9600);
  pinMode(btn0, INPUT);
  pinMode(btn1, INPUT);
}

void loop() {
  Serial.print(digitalRead(btn0));
  Serial.print(",");
  Serial.println(digitalRead(btn1));
}
------------- 
*/

public class Serial_Read_Control : MonoBehaviour
{
    /// <summary>
    /// 시리얼 통신을 담당하는 arduino 객체 생성
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// 시리얼 포트
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// 아두이노가 보내는 데이터를 저장하는 sting 변수
    /// </summary>
    public string serialIn;

    /// <summary>
    /// 아두이노가 송신하는 데이터의 수
    /// </summary>
    public int dataCount = 2;

    public Transform GameObjectToRotate;

    // Start is called before the first frame update
    void Start()
    {
        ///
        // PC에 활성화된 시리얼 포트의 목록 추출
        ///
        string[] ports = SerialPort.GetPortNames();

        ///
        // ports 배열 안에 있는 각 요소(가령, port)를 출력
        foreach (string port in ports)
        {
            print(port);
        }

        ///
        // arduino 객체를 포트 이름, 통신 속도에 맞춰 초기화
        ///
        arduino = new SerialPort(portName.ToString(), 9600);

        ///
        // timeout 설정
        ///
        arduino.ReadTimeout = 100; //0.1초

        ///
        // arduino 포트 개방
        ///
        arduino.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino.IsOpen)
        {
            try
            {
                serialIn = arduino.ReadLine();
                //print("raw:" + serialIn);
                if (serialIn != null)
                {
                    serialIn = serialIn.Trim();
                    //print("trimmed:" + serialIn);

                    string[] serialData = serialIn.Split(',');
                    if (serialData.Length == dataCount)
                    {
                        int data1 = int.Parse(serialData[0]);
                        int data2 = int.Parse(serialData[1]);
                        int dir = 0;
                        if (data1 == 1)
                        {
                            dir = 1;
                        }
                        if (data2 == 1)
                        {
                            dir = -1;
                        }
                        RotateGameObject(dir);
                        print($"angle:{dir}");
                    }
                }
            }
            catch (Exception e)
            {
                //print(e);
            }
        }

    }

    void RotateGameObject(int dir)
    {
        float speed = 90;
        float angle = dir * speed * Time.deltaTime;
        GameObjectToRotate.Rotate(Vector3.up, angle);
    }

    void OnApplicationQuit()
    {
        arduino.Close();
    }
}

