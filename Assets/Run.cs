using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public Camera camera1;
    public Camera camera3;

    public WheelCollider wheelFl;
    public WheelCollider wheelFr;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;

    Transform _raw;
    Transform _pitch;
    float _y;

    // Start is called before the first frame update
    void Start()
    {
        _raw = GameObject.Find("YawÖá").transform;
        _pitch = GameObject.Find("PitchÖá").transform;
        camera3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        wheelBL.motorTorque = Input.GetAxis("Vertical") * 2;
        wheelBR.motorTorque = Input.GetAxis("Vertical") * 2;
        wheelFl.motorTorque = Input.GetAxis("Vertical") * 2;
        wheelFr.motorTorque = Input.GetAxis("Vertical") * 2;

        _y = _raw.localRotation.eulerAngles.y;
        wheelFl.steerAngle = _y;
        wheelFr.steerAngle = _y;

        // ÊÓ½Ç²Ù¿Ø¡ý¡ý
        _raw.Rotate(0, Input.GetAxis("Mouse X"), 0);
        _pitch.Rotate(Input.GetAxis("Mouse Y"), 0, 0);

        // ÉãÏñ»úÇÐ»»¡ý¡ý
        if(Input.GetKeyDown(KeyCode.H))
        {
            if (camera1.enabled)
            {
                camera1.enabled = false;
                camera3.enabled = true;
            }
            else
            {
                camera3.enabled = false;
                camera1.enabled = true;
            }
        }
    }
}
