using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public Button[] levels;
    private int LevelsPassed;
    private int numberofLevels;

    // Start is called before the first frame update
    void Awake()
    {
        numberofLevels = 7;
        LevelsPassed = PlayerPrefs.GetInt("LevelsPassed",2);
        for (int i = 0; i < numberofLevels; i++)
        {   
            if(i < LevelsPassed )
            {
                levels[i].interactable = true;
            }
            else
            {
                levels[i].interactable = false;  
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
