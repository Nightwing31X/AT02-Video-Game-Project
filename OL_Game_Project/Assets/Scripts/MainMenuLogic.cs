using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class MainMenuLogic : MonoBehaviour
{
    private GameObject MainMenu;
    private GameObject OptionsMenu;
    private GameObject ControlsMenu;
    private GameObject Loading;

    public AudioSource ButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu = GameObject.Find("MainMenuCanvas");
        //OptionsMenu = GameObject.Find("OptionsCanvas");
        ControlsMenu = GameObject.Find("ControlsCanvas");
        Loading = GameObject.Find("LoadingCanvas");

        MainMenu.GetComponent<Canvas>().enabled = true;
        //OptionsMenu.GetComponent<Canvas>().enabled = false;
        ControlsMenu.GetComponent<Canvas>().enabled = false;
        Loading.GetComponent<Canvas>().enabled = false;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Demo_Level");
        // Loading.GetComponent<Canvas>().enabled = true;
        // ButtonSound.Play();
    }

    public void OptionsButton()
    {
        ButtonSound.Play();
        MainMenu.GetComponent<Canvas>().enabled = false;
        //OptionsMenu.GetComponent<Canvas>().enabled = true;
    }

    public void ControlsButton()
    {
        ButtonSound.Play();
        MainMenu.GetComponent<Canvas>().enabled = false;
        ControlsMenu.GetComponent<Canvas>().enabled = true;
    }

    public void ExitGameButton()
    {
        ButtonSound.Play();
        Application.Quit();
        Debug.Log("Game has Closed...");
    }

    public void ReturnToMainMenuButton()
    {
        ButtonSound.Play();
        MainMenu.GetComponent<Canvas>().enabled = true;
        //OptionsMenu.GetComponent<Canvas>().enabled = false;
        ControlsMenu.GetComponent<Canvas>().enabled = false;
    }
}
