using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class SentryMove : MonoBehaviour
{
    public Transform point0;
    public Transform point1;
    public Transform target;
    public GameObject bullet;
    public Dispatcher dispatcher;
    Transform _shoot;
    Transform _pitch;
    Transform _platform;

    Vector3 _p0;
    Vector3 _p1;
    Vector3 _destination;
    private Vector3 _v = Vector3.zero;
    RaycastHit _hit;
    int _ready;
    bool _ismove;
    Vector3 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        _shoot = GameObject.Find("shoot").transform;
        _pitch = GameObject.Find("pitch_2").transform;
        _platform = GameObject.Find("ÏÂÔÆÌ¨").transform;
        
        _p0 = point0.position;
        _p1 = point1.position;
        
        StartCoroutine("Move");
        _ismove = true;
        
        _ready = 0;
    }

    void Update()
    {
        _direction = target.position - _shoot.position;
        if (_ismove)
        {
            _platform.Rotate(0,2,0);
            transform.position = Vector3.SmoothDamp(transform.position,_destination,ref _v,0.8f);
        }
        Physics.Raycast(_shoot.position, _direction, out _hit);
        if (_hit.collider.name == "Standard")
        {
            _ismove = false;
            Defend();
        }
        else
        {
            if (!_ismove)
                _ismove = true;
        }
    }
    void Defend()
    {
        _platform.rotation = Quaternion.LookRotation(new Vector3(_direction.z, 0, -_direction.x));
        _pitch.rotation = Quaternion.LookRotation(-_direction);
        if (_ready == 1000)
        {
            GameObject b = Instantiate(bullet, _shoot);
            b.GetComponent<Rigidbody>().AddForce(_direction.normalized * 10, ForceMode.Impulse);
            Destroy(b, 1);
            _ready = 0;
        }
        else
            _ready += 1;
    }
    IEnumerator Move()
    {
        while (true)
        {
            _destination = _p0 + Random.value * (_p1 - _p0);
            yield return new WaitForSeconds(1);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet")) 
            dispatcher.SeHurt();
    }
}