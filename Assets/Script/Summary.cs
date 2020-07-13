using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public Text status;
    public Text score;
    public Text life;
    public Text defeat;
    //remaining health and number of enemies defeated - Z
    public List<Image> flames;
    public GameObject nextBtn;
    public GameObject minishop;
    public LocalScoreManager lsm;
    public GameObject flicker;
    //to get flicker health - Z

    public Animator fireAnimator;

    public int NoCoal;
    //number of coals in level -Z

    private Canvas summaryCanvas;
    private PlayerHealth health;
    // - Z

    bool levelNotCleared;

    void Awake()
    {
        summaryCanvas = GetComponent<Canvas>();
    }

    void Start()
    {
        levelNotCleared = true;
        health = flicker.GetComponent<PlayerHealth>();
    }

    public void ClearLevel()
    {
        levelNotCleared = false;

        lsm.SaveNewHighScore();
        
        Time.timeScale = 0f;
            
        status.text = "LIT!";
        if (lsm.GetLevelScore() == NoCoal)
        {
            score.text = "All";
        }
        else
        {
            score.text = lsm.GetLevelScore().ToString();
        }
        life.text = health.playerHealth.ToString() + "%";
        if (GameObject.FindGameObjectWithTag ("Enemy") == null)
        {
            defeat.text = "All";
        }
        else
        {
            defeat.text = "0";
        }
        //conditions for level summary achievement display - Z
        


        if ((lsm.GetLevelScore() == NoCoal) && (health.playerHealth > 60) && (GameObject.FindGameObjectWithTag ("Enemy") == null))
        {
            fireAnimator.SetTrigger("Three");
            //3 flames is perfect score, all coals collected, green health and all enemies defeated - Z
        }
        else if ((lsm.GetLevelScore() > NoCoal/3) && (health.playerHealth > 30))
        {
            fireAnimator.SetTrigger("Two");
        }
        else
        {
            fireAnimator.SetTrigger("One");
        }

        if (summaryCanvas != null)
        {
            summaryCanvas.enabled = true;
        }
    }

    public void NotClearLevel()
    {
        if (levelNotCleared)
        {
            Time.timeScale = 0f;

            nextBtn.GetComponent<Button>().interactable = false;
            minishop.SetActive (false);  

            status.text = "EXTINGUISHED!";
            if (lsm.GetLevelScore() == NoCoal)
            {
                score.text = "All";
            }
            else
            {
                score.text = lsm.GetLevelScore().ToString();
            }

            life.text = health.playerHealth.ToString() + "%";

            if (GameObject.FindGameObjectWithTag ("Enemy") == null)
            {
                defeat.text = "All";
            }
            else
            {
                defeat.text = "0";
            }
        //conditions for level summary achievement display - Z

            if (summaryCanvas != null)
            {
                summaryCanvas.enabled = true;
            }
        }
    }
}
