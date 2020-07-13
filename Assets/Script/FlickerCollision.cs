using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerCollision : MonoBehaviour
{

    Vector3 high;
    Vector3 low;
    
    public float minimum;
    public float maximum;
    public float  height;
    public bool collided;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        if (collision.gameObject.CompareTag("GlassPlatform"))
        {
           high = collision.gameObject.GetComponent<SpriteRenderer>().bounds.max;
           low = collision.gameObject.GetComponent<SpriteRenderer>().bounds.min;
           minimum = low.x;
           maximum = high.x;
           height = high.y;  
        }
    }

}
