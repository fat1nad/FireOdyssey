using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ScreenLoader : MonoBehaviour
{
    public Canvas OptionsMenu;
    public Canvas CurrentCanva;
    private bool Wait;

    public void LoadScreen(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }  

    IEnumerator LoadAsynchronously(string sceneName)
    {
        //yield return new WaitForSeconds(1.2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
        
    }

    public void HelpButton()
    {
        SceneManager.LoadScene ("HelpScreen");
    }

    public void OptionsButton()
    {
        var Options = Instantiate(OptionsMenu, OptionsMenu.GetComponent<RectTransform>().position, OptionsMenu.GetComponent<RectTransform>().rotation);
        Options.transform.SetParent(CurrentCanva.transform,false); 
    }
    


    public void ShopScreen()
    {
        SceneManager.LoadScene ("ShopScreen");
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene ("TitleScreen");
    }

    
    public void GameScreen(GameObject gameObject)
    {
        string level = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        if (level == "1")
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            level = (Convert.ToInt32(level) - 2).ToString();
            //Debug.Log(level);
            SceneManager.LoadScene ("GameScreen"+ level);
        }
        
    }//Hi, so i changed GetChild(int) to 3 because the ui i have added for levels has children images too,
     //it works fine don't worry - Z
    
}
