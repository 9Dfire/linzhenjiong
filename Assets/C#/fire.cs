using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform standard;
    public Transform dir;
    GameObject B;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            B = Instantiate(bullet, transform.position, transform.rotation);
            B.GetComponent<Rigidbody>().AddForce((dir.position - transform.position) * 20, ForceMode.Impulse);
            Destroy(B, 3);
        }
    }

}
