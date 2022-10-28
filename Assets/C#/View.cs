using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class View : MonoBehaviour
{
    public Camera camera1;
    public Camera camera3;
    public Image sight;
    Transform _pitch;

    // Start is called before the first frame update
    void Start()
    {
        _pitch = GameObject.Find("PitchÖá").transform;
        camera3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        _pitch.Rotate(Input.GetAxis("Mouse Y"), 0, 0);
        // ÉãÏñ»úÇÐ»»¡ý¡ý
        if(Input.GetKeyDown(KeyCode.H))
        {
            if (camera1.enabled)
            {
                camera1.enabled = false;
                sight.enabled = false;
                camera3.enabled = true;
            }
            else
            {
                camera3.enabled = false;
                camera1.enabled = true;
                sight.enabled = true;
            }
        }
    }
}
