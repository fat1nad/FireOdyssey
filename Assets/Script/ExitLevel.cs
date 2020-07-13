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
     private string scenename;
    private int currentlevel;


    void Awake()
    {
        scenename = SceneManager.GetActiveScene().name;
        currentlevel =  int.Parse(scenename.Substring(scenename.Length-1));
    }
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

             if (currentlevel+3 > PlayerPrefs.GetInt("LevelsPassed",1))
            {
                PlayerPrefs.SetInt("LevelsPassed", currentlevel+3);

            }
            
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
