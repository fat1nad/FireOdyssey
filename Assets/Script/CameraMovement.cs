using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject flicker;
    //public Summary summary;
    public GameObject RBoundary;
    public GameObject LBoundary;
    public GameObject Ground;

    Vector3 offset;
    float Rborder;
    //float values of game borders
    float Lborder;
    float Gborder;
    Camera cam;
    //bool NCLNotCalled;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - flicker.transform.position;
        //transform.position = flicker.transform.position + offset;
        Rborder = RBoundary.transform.position.x - 8f;
        //offset values for game borders so they can be moved around each level without affecting movement-Z
        Lborder = LBoundary.transform.position.x + 8f;
        Gborder = Ground.transform.position.y + 3.75f;
        cam = GetComponent<Camera>();
        //NCLNotCalled = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if (flicker.transform.position.x > Lborder && flicker.transform.position.x < Rborder) 
        //float range for level boundary-Z
        {
            if (flicker.transform.position.y > Gborder) 
            //edited flaot value-Z
            {
                transform.position = flicker.transform.position + offset; //There might be a bool value here eventually for when game ends
            }
            else 
            //stop vertical cam movement-Z
            {
                transform.position = new Vector3(flicker.transform.position.x + offset.x, transform.position.y, transform.position.z);
            }
        }
        else 
        //to stop cam movement at boundaries-Z
        {
            if (flicker.transform.position.y < Gborder)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            else 
            //enables vertical movement at boundary when not on ground-Z
            {
                transform.position = new Vector3(transform.position.x, flicker.transform.position.y + offset.y, transform.position.z);
            }
        }
        // if ((cam.WorldToScreenPoint(flicker.transform.position).y < -97) && NCLNotCalled)
        // {
        //     NCLNotCalled = false;
        //     summary.NotClearLevel();   
        // }

    }
}
