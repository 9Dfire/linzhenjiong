using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    public Robot Infantry;
    public Scrollbar myLife;

    // Start is called before the first frame update
    void Start()
    {
        Infantry = new Robot(200, 5);
    }

    // Update is called once per frame
    void Update()
    {
        myLife.size = Infantry.Life / 200f;
    }
    void OnCollisionEnter(Collision collision)
    {
        print("yyy");
        if (collision.gameObject.CompareTag("bullet"))
        {
            
            Infantry.Life -= 5;
        }
    }

}
