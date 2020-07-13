using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    public Canvas pause;
    public Canvas subshop;
    public Canvas ItemBought;
    public Canvas subshop2;
    public Canvas ItemBought2;

    public ScoreManager sc;

    public void OnMouseClick_BoughtItem()
    {
        subshop.enabled = false;
        ItemBought.enabled = !ItemBought.enabled;
        ItemBought.enabled = true;
    }

    public void OnMouseClick_FreezeGame() //relevant to gamescreen
    {
        Time.timeScale = 0f;
    }
    public void OnMouseClick_UnfreezeGame() //relevant to gamescreen
    {
        Time.timeScale = 1f;
    }

    public void OnMouseClick_BoughtItem2()
    {
        subshop2.enabled = false;
        ItemBought2.enabled = !ItemBought2.enabled;
        ItemBought2.enabled = true;
    }

    public void OnMouseClick_ReplayLevel()  //relevant to gamescreen
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScreen");
    }

    public void OnMouseClick_NextLevel()  //relevant to gamescreen
    {
        // For the time being we are loading the same scene instead
        // Will change to another level when we have more levels
        Time.timeScale = 1f;
        SceneManager.LoadScene ("GameScreen");
    }
    
    public void OnMouseClick_MainMenu() //relevant to gamescreen
    {
        sc.ResetLevelScore();
        Time.timeScale = 1f;
        SceneManager.LoadScene ("TitleScreen");
    }

    public void OnMouseClick_LevelSelect() //relevant to gamescreen
    {
        Time.timeScale = 1f;
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
