using UnityEngine;
using System;

public class LeftHandMode : MonoBehaviour
{
    static public LeftHandMode instance;

    public InGameLHMManager inGameLHMM;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetLeftHandMode(bool mode)
    {
        int boolInt = mode ? 1 : 0;

        PlayerPrefs.SetInt("LeftHandMode", boolInt);

        if (inGameLHMM != null)
        {
            inGameLHMM.GetLeftHandMode();
        }
    }



    



}
