using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public Summary summary;
    public AudioClip PowerUpSFX;

    private GameObject outermask;
    private GameObject innermask;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        outermask = this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
        innermask = this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= 25;
            //Destroy(collision.gameObject);
            if (outermask.transform.localScale.x > 0.55f)
            {
                outermask.transform.localScale -= new Vector3(0.3f,0.3f,0.3f);
            }
            if (innermask.transform.localScale.x > 0.99f)
            {
                innermask.transform.localScale -= new Vector3(0.7f,0.7f,0.7f);

            }


            // Can place following code anywhere where decrement in health is called
            if (playerHealth <= 0)
            {
                summary.NotClearLevel();
            }
        }
        else if (collision.gameObject.CompareTag("Healer"))
        {
            playerHealth = 100;
            Destroy(collision.gameObject);
            this.GetComponent<AudioSource>().PlayOneShot(PowerUpSFX);
            outermask.transform.localScale = new Vector3(1.6f,1.6f, 1.6f);
            innermask.transform.localScale = new Vector3(2.7f,2.7f,2.7f);
        }
    }
}
