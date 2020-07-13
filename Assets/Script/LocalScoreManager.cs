using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT SHOULD BE CALLED LOCALCOUNTMANAGER AND ALL TERMS SHOULD CHANGE ACCORDINGLY

public class LocalScoreManager : MonoBehaviour
{
    private Text scoreText;
    private int score;  

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    void Start()
    {
        score = 0;  // Always resets score at the start of each level

        if (scoreText != null)
        {
            scoreText.text = "x" + score.ToString();
        }
    }

    public void ChangeLevelScore(int addVal)  // To update as coals/diamonds get collected
    {
        score += addVal;

        if (scoreText != null)
        {
            scoreText.text = "x" + score.ToString();
        }
    }

    public int GetLevelScore()  // For summary
    {
        return score;
    }

    public void SaveNewHighScore()  // For summary  // SHOULD BE SAVENEWTOTALCOUNT()
    {
        if (gameObject.name == "Score")  // SHOULD BE COALS ://
        {
            ScoreManager.instance.AddToHighScore(score);
        }
        else if (gameObject.name == "Diamonds")
        {
            TotalDiamondsManager.instance.AddToDiamondCount(score);
        }       
    }










}
