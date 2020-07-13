using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Summary summary;
    public Canvas gameCanvas;
    public GameObject flickerBackLight;

    public AudioClip deathSFX;

    public void FallOut()
    {
        if (gameCanvas != null)
        {
            gameCanvas.enabled = false;
        }
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(deathSFX);
        summary.NotClearLevel();
    }

    public void Killed()  // When Flicker is killed by enemy
    {
        if (gameCanvas != null)
        {
            gameCanvas.enabled = false;
        }

        // death animation

        GetComponent<AudioSource>().PlayOneShot(deathSFX);
        summary.NotClearLevel();
    }

    public void FallDeath()  // When Flicker falls from a fatal height and hits ground
    {
        if (gameCanvas != null)
        {
            gameCanvas.enabled = false;
        }

        GetComponent<ParticleSystem>().Play();

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        GetComponent<SpriteRenderer>().enabled = false;
        flickerBackLight.SetActive(false);

        GetComponent<PlayerHealth>().enabled = false;

        GetComponent<AudioSource>().PlayOneShot(deathSFX);
        StartCoroutine(FD());
    }

    IEnumerator FD()
    {
        yield return new WaitForSeconds(3f);
        summary.NotClearLevel();
    }

}
