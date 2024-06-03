using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour { 

    public GameObject MenuParent;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public GameObject resumeBTN;
    public GameObject optionsBTN;
    public GameObject exitBTN;

    public GameObject PlayerHUD;
    public PlayerController cutsceneCHECK;

    public MouseLook mouselook;  //# Lets me reference things from another C# file
    public Camera blurCamera;

    public bool pauseMenuON;
    public bool pauseMenuOFF;

   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PostProcessVolume ppVolume = blurCamera.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;
        MenuParent.SetActive(true);
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        pauseMenuOFF = true;
        pauseMenuON = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.Find("clipboard_model").GetComponent<NoteInteraction>().readingActive == false)
        //{
            //Debug.Log("TRUE...");
        PostProcessVolume ppVolume = blurCamera.GetComponent<PostProcessVolume>();
        Debug.Log(cutsceneCHECK.inCutscene);
        if (pauseMenuOFF && Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0;
            mouselook.LookEnabled = false;
            ppVolume.enabled = true;
            //MenuParent.SetActive(true);
            PauseMenu.SetActive(true);
            PlayerHUD.SetActive(false);
            pauseMenuOFF = false;
            pauseMenuON = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (pauseMenuON && Input.GetButtonDown("Pause"))
        {
            if (cutsceneCHECK.inCutscene)
            {
                Time.timeScale = 1;
                mouselook.LookEnabled = true;
                ppVolume.enabled = false;
                //MenuParent.SetActive(false);
                PauseMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                pauseMenuOFF = true;
                pauseMenuON = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else 
            {
                Time.timeScale = 1;
                mouselook.LookEnabled = true;
                ppVolume.enabled = false;
                //MenuParent.SetActive(false);
                PauseMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                PlayerHUD.SetActive(true);
                pauseMenuOFF = true;
                pauseMenuON = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        //}
    }

    public void Resume()
    {
        if (cutsceneCHECK.inCutscene)
        {
            Time.timeScale = 1;
            mouselook.LookEnabled = true;
            PostProcessVolume ppVolume = blurCamera.GetComponent<PostProcessVolume>();
            ppVolume.enabled = false;
            //MenuParent.SetActive(false);
            PauseMenu.SetActive(false);
            pauseMenuOFF = true;
            pauseMenuON = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 1;
            mouselook.LookEnabled = true;
            PostProcessVolume ppVolume = blurCamera.GetComponent<PostProcessVolume>();
            ppVolume.enabled = false;
            //MenuParent.SetActive(false);
            PauseMenu.SetActive(false);
            PlayerHUD.SetActive(true);
            pauseMenuOFF = true;
            pauseMenuON = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Options()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        //Debug.Log("Button Clicked...OptionsMenu Opened");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        //Application.Quit();
    }

}




