using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{

    private Single defaultSoundVolume;
    private Single defaultMusicVolume;
    private bool defaultleftHandMode;
    private bool Change;

    public AudioMixer audioMixer;
    public AudioMixer soundMixer;

    public Slider volumeSliderSound;
    public Slider volumeSliderMusic;
    public Toggle enableLeftHand;

    #region Player Pref Key Constants

    private const string MUSIC_VOLUME_PREF = "music-volume";
    private const string SFX_VOLUME_PREF = "sound-volume";
    private const string LEFTHAND_PREF = "LeftHandMode";

    #endregion

// Start is called before the first frame update
    void Start()
    {
        volumeSliderMusic.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_PREF, 1);
        volumeSliderSound.value = PlayerPrefs.GetFloat(SFX_VOLUME_PREF, 1);
        enableLeftHand.isOn = GetBoolPref(LEFTHAND_PREF, false);
        Change = false;

    }
    public void OptionsDestroy()
    {
        Destroy(GameObject.Find("OptionsMenu(Clone)"));
    }

    private void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    private void SetSFXVolume(float volume)
    {
        soundMixer.SetFloat("SoundVolume", volume);
    }

    public Canvas optionsCanva;
    public Canvas pauseCanva;
    public void ExitOptions()
    {
        if (Change)
        {

            PopUps pop= GameObject.FindGameObjectWithTag("OptionsManager").GetComponent<PopUps>();
            pop.PopUp("Save current changes?");
        }
        else{
            optionsCanva.gameObject.SetActive(false);
            pauseCanva.enabled= true;

        }
    }

    public void Toggle()
    {
        Change = true;
    }

    
    public void OnChangeSoundVolume(Single value)
    {
        defaultSoundVolume = value;
        Change = true;
    }

    public void OnChangeMusicVolume(Single value)
    {
        defaultMusicVolume = value;
        Change = true;
    }

    public void UpdateOptions()
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME_PREF, defaultMusicVolume);
        PlayerPrefs.SetFloat(SFX_VOLUME_PREF, defaultSoundVolume);
        SetPref(LEFTHAND_PREF, defaultleftHandMode);
        SetMainVolume(defaultMusicVolume);
        SetSFXVolume(defaultSoundVolume);
        optionsCanva.gameObject.SetActive(false);
        pauseCanva.enabled= true;

    }       

    public void CancelOptions()
    {
        defaultleftHandMode = GetBoolPref(LEFTHAND_PREF, false);
        defaultMusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_PREF,1);
        defaultSoundVolume = PlayerPrefs.GetFloat(SFX_VOLUME_PREF,1);
        optionsCanva.gameObject.SetActive(false);
        pauseCanva.enabled= true;
    }


    #region Pref Setters

    private bool GetBoolPref(string key, bool defaultValue = true)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(key, Convert.ToInt32(defaultValue)));
    }


    private void SetPref(string key, bool value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    #endregion
}
