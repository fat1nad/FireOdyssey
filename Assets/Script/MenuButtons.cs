using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    public Canvas pause;
    public int LevelNumber;
    public bool LevelS;
    public GameObject S;

    public void OnMouseClick_FreezeGame() //relevant to gamescreen
    {
        Time.timeScale = 0f;
    }
    public void OnMouseClick_UnfreezeGame() //relevant to gamescreen
    {
        Time.timeScale = 1f;
    }

    public void OnMouseClick_ReplayLevel()  //relevant to gamescreen
    {
        Time.timeScale = 1f;
        if (LevelNumber == -1)
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else{
        SceneManager.LoadScene("GameScreen" + LevelNumber);
        }
    }

    public void OnMouseClick_NextLevel()  //relevant to gamescreen
    {
        // For the time being we are loading the same scene instead
        // Will change to another level when we have more levels
        Time.timeScale = 1f;
        SceneManager.LoadScene ("GameScreen" + (LevelNumber + 1));
    }
    
    public void OnMouseClick_MainMenu() //relevant to gamescreen
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene ("TitleScreen");
    }

    public void OnMouseClick_LevelSelect() //relevant to gamescreen
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene ("LevelSelect");
    }
    public void OnMouseClick_HelpScreen() 
    {
        SceneManager.LoadScene ("HelpScreen");
    }
    public void OnMouseClick_ExitHelp() 
    {
        SceneManager.LoadScene ("LevelSelect");
    }
    public void OnMouseClick_ShopScreen()
    {
        SceneManager.LoadScene ("ShopScreen");
    }
    public void OnMouseClick_PurchaseScreen()
    {
        SceneManager.LoadScene ("PurchaseScreen");
    }
}
