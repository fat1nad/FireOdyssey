using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlatform : MonoBehaviour
{
    //public GameObject Reflect;
    public GameObject jumpLight;
    public GameObject flicker;
    private PlayerMovement MJ;
    private FlickerCollision colCheck;

    //GameObject Reflection;
    GameObject Light;
    Vector3 LightPos;
    bool check;

    void Start()
    {
        MJ = flicker.GetComponent<PlayerMovement>();  
        colCheck = flicker.GetComponent<FlickerCollision>();
    }
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     { 
    //        Reflection = Instantiate(Reflect, transform.position, Reflect.transform.rotation);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
    //    if (GetComponent<Collider2D>().IsTouching(flicker.GetComponent<Collider2D>()))
    //    {
    //        Reflection.transform.position = new Vector3 (flicker.transform.position.x, flicker.transform.position.y-2, flicker.transform.position.z);
    //        Reflection.transform.rotation = Quaternion.Euler (Reflect.transform.eulerAngles.x, flicker.transform.eulerAngles.y, Reflect.transform.eulerAngles.z);
    //    }
    //    else
    //    {
    //        Destroy(Reflection);
    //    }
        if (check == true)
        {
            if (flicker.transform.position.x >= colCheck.minimum && flicker.transform.position.x <= colCheck.maximum && flicker.transform.position.y >= colCheck.height)
                {
                    Light.GetComponent<SpriteRenderer>().enabled = true;
                    Light.transform.position = new Vector3 (flicker.transform.position.x, flicker.transform.position.y - 3, flicker.transform.position.z);
                    if (colCheck.collided == true)
                    {
                        //StopCoroutine(reflection());
                        Destroy(Light);
                        check = false;
                    }
                }       
                else
                {
                    //StopCoroutine(reflection());
                    Destroy(Light);
                    check = false;
                }
        }
       
        if (MJ.MirrorJump == true && check == false)
        {
            colCheck.collided = false;
            StartCoroutine(reflection());
            MJ.MirrorJump = false;
            
        }
    }

    IEnumerator reflection()
    {
        yield return new WaitForSeconds(0.07f);
        Light = Instantiate(jumpLight, new Vector3 (flicker.transform.position.x, flicker.transform.position.y - 3, flicker.transform.position.z), jumpLight.transform.rotation);
        Light.GetComponent<SpriteRenderer>().enabled = false;
        check = true;
        yield return new WaitForSeconds(0.7f);
        Destroy(Light);
        check = false;
    }
}
