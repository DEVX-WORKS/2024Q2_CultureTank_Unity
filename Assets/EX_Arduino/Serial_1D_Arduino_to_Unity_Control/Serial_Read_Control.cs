using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * �Ʒ��� System.IO.Ports�� ����ϱ� ���ؼ���
 * Unity Editor > Edit > Project Settings > Player > Other Settings > Configuration > Api Compatibility Level��
 * .NET 4.x�� �����ϰ� Unity Editor�� �ٽ� �����ؾ� �� * 
 */
using System.IO.Ports;

using System; // catch exception ó���� ���� ���

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
    /// �ø��� ����� ����ϴ� arduino ��ü ����
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// �ø��� ��Ʈ
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// �Ƶ��̳밡 ������ �����͸� �����ϴ� sting ����
    /// </summary>
    public string serialIn;

    /// <summary>
    /// �Ƶ��̳밡 �۽��ϴ� �������� ��
    /// </summary>
    public int dataCount = 2;

    public Transform GameObjectToRotate;

    // Start is called before the first frame update
    void Start()
    {
        ///
        // PC�� Ȱ��ȭ�� �ø��� ��Ʈ�� ��� ����
        ///
        string[] ports = SerialPort.GetPortNames();

        ///
        // ports �迭 �ȿ� �ִ� �� ���(����, port)�� ���
        foreach (string port in ports)
        {
            print(port);
        }

        ///
        // arduino ��ü�� ��Ʈ �̸�, ��� �ӵ��� ���� �ʱ�ȭ
        ///
        arduino = new SerialPort(portName.ToString(), 9600);

        ///
        // timeout ����
        ///
        arduino.ReadTimeout = 100; //0.1��

        ///
        // arduino ��Ʈ ����
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

