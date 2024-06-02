using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuLogic : MonoBehaviour
{
    private GameObject PauseMenu;
    private GameObject OptionsMenu;

    public AudioMixer audioMixer;

    void Awake()
    {
        PauseMenu = GameObject.Find("PauseMenuCanvas");
        OptionsMenu = GameObject.Find("OptionsMenuCanvas");

        if (PauseMenu == null || OptionsMenu == null)
        {
            //Debug.Log("Make sure that all the children under MenuPaused (itself doesn't need to be on) are turned on before playing.");
            //Debug.Log(PauseMenu);
            //Debug.Log(OptionsMenu);
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        //Debug.Log(volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ReturnToPauseMenuButton()
    {
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        Debug.Log("Button Clicked...Return");
    }

}
