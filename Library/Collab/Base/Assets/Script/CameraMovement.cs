using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject flicker;
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

        if (flicker.transform.position.y > -8f) //There might be a bool value here eventually for when game ends
        {
            transform.position = flicker.transform.position + offset;
        }

        if ((cam.WorldToScreenPoint(flicker.transform.position).y < -97) && NCLNotCalled)
        {
            NCLNotCalled = false;
            summary.NotClearLevel();   
        }

    }
}
