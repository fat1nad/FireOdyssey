using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject flicker;
    public GameObject grass;
    public Summary summary;

    Vector3 offset;
    Camera cam;
    bool NCLNotCalled;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - flicker.transform.position;
        cam = GetComponent<Camera>();
        NCLNotCalled = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 change = flicker.transform.position + offset;

        //if (flicker.transform.position.y > -6f) //There might be a bool value here eventually for when game ends
        if (cam.WorldToScreenPoint(grass.transform.position).y < 145.5f)  // 145.5 is half of grass sprite's height; this it to check if ALL of it is in the camera's view
        {
            transform.position = change;
        }
        else if (change.y > transform.position.y)
        {
            transform.position = change;
        }

        if ((cam.WorldToScreenPoint(flicker.transform.position).y < -96.5f) && NCLNotCalled)  // 96.5 is half of flicker sprite's height; this it to check if ALL of it out of camera's view
        {
            NCLNotCalled = false;
            summary.NotClearLevel();   
        }

    }
}
