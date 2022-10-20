using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SentryMove : MonoBehaviour
{
    public Transform point0;
    public Transform point1;
    public Transform pitch;
    public Transform target;
    public GameObject bullet;

    Vector3 _p0;
    Vector3 _p1;
    Vector3 _destination;
    RaycastHit _hit;
    int _ready;

    public Robot Sentry = new Robot(100, 5);
    
    // Start is called before the first frame update
    void Start()
    {
        _p0 = point0.position;
        _p1 = point1.position;
        StartCoroutine("Move");
        _ready = 0;
    }

    void Update()
    {
        transform.Translate((_destination - transform.position) * 0.01f, Space.World);
        Physics.Raycast(pitch.position, target.position - pitch.position, out _hit);        
        if (_hit.collider.name == "±£»¤¿Ç")
        {
            StopCoroutine("Move");
            _destination = transform.position;
            if (_ready == 100)
            {
                GameObject b = Instantiate(bullet, pitch);
                b.GetComponent<Rigidbody>().AddForce((target.position - pitch.position).normalized * 10, ForceMode.Impulse);
                Destroy(b, 1);
                _ready = 0;
            }
            else
                _ready += 1;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            _destination = _p0 + Random.value * (_p1 - _p0);
            yield return new WaitForSeconds(2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet")
            Sentry.Life -= collision.gameObject.GetComponent<fire>().Infantry.Power;
    }
}
