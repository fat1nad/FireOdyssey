using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollection : MonoBehaviour
{
    public LocalScoreManager clsm;
    //public LocalScoreManager dlsm;

    public AudioClip coalSound;
    //public AudioClip diamondSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coal"))  // If collided object is tagged with tag Coal
        {
            GetComponent<AudioSource>().PlayOneShot(coalSound);
            Destroy(collision.gameObject);

            if (clsm != null)
            {
                clsm.ChangeLevelScore(1);
            }
        }
        //else if(collision.gameObject.CompareTag("Diamond"))  // If collided object is tagged with tag diamond
        //{
        //    GetComponent<AudioSource>().PlayOneShot(diamondSound);

        //    Destroy(collision.gameObject);

        //    if (dlsm != null)
        //    {
        //        dlsm.ChangeLevelScore(1);
        //    }
        //}
    }
}
