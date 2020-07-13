using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitLevel : MonoBehaviour
{
    public Summary summary;

    //public GameObject Flame;

    public GameObject flickerGlow;
    public GameObject EnemyB;
    public Canvas GameCanvas;
    public GameObject HelpExit;
    public bool HelpScreeen;
    public AudioClip WinSFX;
    public AudioSource audioSource;
    public Animator MaskAnimator;
    public GameObject flameWhisps;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().enabled = false;
            other.GetComponent<Animator>().SetBool("isWalking", false);
            GameCanvas.enabled = false; 
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            EnemyB.SetActive (false);
            audioSource.PlayOneShot(WinSFX);
            MaskAnimator.SetTrigger("gameend");
            
            //disabling flicker movement and UI - Z

            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        flickerGlow.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        //Flame.SetActive (true);
        
        flameWhisps.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.25f);
        if (HelpScreeen)
        {
            HelpExit.SetActive (true);
        }
        else
        {
            summary.ClearLevel();
        }
        
        
        
        //Animations added -Z

    }
}
