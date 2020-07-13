using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToggleGlobalSetting : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("LeftHandMode", 0));
    }
}
