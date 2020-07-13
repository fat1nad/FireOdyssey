using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
// THIS SCRIPT SHOULD BE CALLED TOTALCOALSMANAGER AND ALL TERMS IN THIS SCRIPT SHOULD CHANGE ACCORDINGLY

    static public ScoreManager instance;
    private int oldHS;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        //ResetHighScore();  // TO BE REMOVE BEFORE SUBMISSION. ONLY FOR TESTING

        oldHS = PlayerPrefs.GetInt("HighScore", 0);  
    }

    public int GetHighScore()  // To be used by shop to get remaining coals
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public bool DeductFromHighScore(int deductVal)  // To be used by shop when an item is bought
    {
        oldHS = PlayerPrefs.GetInt("HighScore", 0);

        int globalScore = oldHS;

        if (globalScore >= deductVal)
        {
            globalScore = globalScore - deductVal;

            PlayerPrefs.SetInt("HighScore", globalScore);

            return true;
        }

        return false;
    }

    public void AddToHighScore(int addVal)  // For summary and shop (if diamonds buy coals)
    {
        oldHS = PlayerPrefs.GetInt("HighScore", 0);

        int globalScore = oldHS + addVal;

        PlayerPrefs.SetInt("HighScore", globalScore);
    }

    //public void ResetHighScore()  // TO BE REMOVED ONCE GAME IS FULLY MADE. COMMENT OUT BEFORE SUBMISSION. ONLY FOR TESTING
    //{
    //    PlayerPrefs.DeleteKey("HighScore");
    //}

}
