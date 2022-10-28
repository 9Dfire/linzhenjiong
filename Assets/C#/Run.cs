using UnityEngine;

public class Run : MonoBehaviour
{
    public WheelCollider wheelFl;
    public WheelCollider wheelFr;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;
    public Dispatcher dispatcher;
    public Transform raw;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        wheelFl.steerAngle = 40;
        wheelFr.steerAngle = -42;
        wheelBL.steerAngle = -42;
        wheelBR.steerAngle = 40;
    }

    public int speed = 4;
    // Update is called once per frame
    void Update()
    {
        
        float ve = Input.GetAxis("Vertical");
        float ho = Input.GetAxis("Horizontal");
        wheelBL.motorTorque = (ve + ho) * speed;
        wheelBR.motorTorque = (ve - ho) * speed;
        wheelFl.motorTorque = (ve - ho) * speed;
        wheelFr.motorTorque = (ve + ho) * speed;
        // ��ͷ�������
        raw.position = transform.position + 0.2f * Vector3.up;
        // ����������
        float lry = (raw.rotation.eulerAngles - transform.rotation.eulerAngles).y * 0.1f;
        print(lry);
        if (lry != 0)
        {
            wheelFl.motorTorque += -lry ;
            wheelFr.motorTorque += lry ;
            wheelBL.motorTorque += -lry ;
            wheelBR.motorTorque += lry ;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet")) 
            dispatcher.InHurt();
    }
}
