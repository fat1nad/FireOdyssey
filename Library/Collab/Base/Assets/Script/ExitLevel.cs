using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ExitLevel : MonoBehaviour
{
    public Summary summary;

    //public GameObject Flame;
    
    //public GameObject Glow;
    public GameObject EnemyB;
    public Canvas GameCanvas;
    public GameObject HelpExit;
    public bool HelpScreeen;
    public AudioClip WinSFX;
    public AudioSource audioSource;
    public Animator MaskAnimator;
    private string scenename;
    private int currentlevel;

    ParticleSystem flame;

    void Awake()
    {
        flame = GetComponent<ParticleSystem>();
        scenename = SceneManager.GetActiveScene().name;
        currentlevel =  Convert.ToInt32(scenename.Substring(scenename.Length-1));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().enabled = false;
            GameCanvas.enabled = false; 
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            EnemyB.SetActive (false);
            audioSource.PlayOneShot(WinSFX);
            MaskAnimator.SetTrigger("gameend");
            if (currentlevel > PlayerPrefs.GetInt("LevelPassed",1))
            {
                PlayerPrefs.SetInt("LevelPassed", currentlevel);
            }
            
            //disabling flicker movement and UI - Z

            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        //Glow.SetActive(true);  
        yield return new WaitForSeconds(0.5f);
        //Flame.SetActive (true);
        flame.Play();
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
