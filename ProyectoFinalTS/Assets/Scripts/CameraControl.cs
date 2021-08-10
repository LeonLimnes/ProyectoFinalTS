using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    //Camera speed
    [SerializeField] float CameraSensitivity = 150.0f;
    //Reference to the body of the player
    [SerializeField] Transform PlayerBody;

    [SerializeField] Transform head;
    //The Gyroscope from the device
    Gyroscope m_Gyro;
    //rotaiton x
    float xRotation = 0f;
    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        


        //if (SystemInfo.supportsGyroscope)
        //{
        //    PlayerBody.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        //    transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        //}
        float cameraX = Input.GetAxis("Right Stick X") * CameraSensitivity * Time.deltaTime;
        float cameraY = Input.GetAxis("Right Stick Y") * CameraSensitivity * Time.deltaTime;
            xRotation += cameraY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            head.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * cameraX);






    }
}
