using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform standard;
    public Transform dir;
    public Scrollbar MyLife;
    GameObject B;
    public Robot Infantry = new Robot(200, 5);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            B = Instantiate(bullet, transform.position, transform.rotation);
            B.GetComponent<Rigidbody>().AddForce((dir.position - transform.position) * 20, ForceMode.Impulse);
            Destroy(B, 3);
        }

        MyLife.size = Infantry.Life / 200;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet")
            Infantry.Life -= collision.gameObject.GetComponent<SentryMove>().Sentry.Power;
    }

}
