using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WoodenPlatform : MonoBehaviour
{
    public AudioClip burnSFX;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TouchedPlatform(collision.gameObject));
        }  
    }

    IEnumerator TouchedPlatform(GameObject platform)
    {
        this.GetComponent<AudioSource>().PlayOneShot(burnSFX);
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        yield return new WaitForSeconds(2f);
        ps.Stop();
        Destroy(this.gameObject);
    }
}
