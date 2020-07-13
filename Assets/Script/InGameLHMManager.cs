using UnityEngine;
using System;

public class InGameLHMManager : MonoBehaviour
{
    public GameObject moveJ;
    public GameObject shootJ;

    public Transform defaultMovePos;
    public Transform defaultShootPos;

    void Start()
    {
        GetLeftHandMode();
    }

    public void GetLeftHandMode()
    {
        bool mode = Convert.ToBoolean(PlayerPrefs.GetInt("LeftHandMode", 0));

        if (mode)
        {
            moveJ.transform.position = defaultShootPos.position;
            shootJ.transform.position = defaultMovePos.position;
        }
        else
        {
            moveJ.transform.position = defaultMovePos.position;
            shootJ.transform.position = defaultShootPos.position;
        }
    }

}
