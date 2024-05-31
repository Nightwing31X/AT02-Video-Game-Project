using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{
    public GameObject Menu;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public GameObject resume;
    public GameObject options;
    public GameObject quit;

    [SerializeField] private GameObject PlayerHUD;

    [SerializeField] private MouseLook script;  //# Lets me reference things from another C# file
    public Camera blurCamera;

    public bool pauseMenuON;
    public bool pauseMenuOFF;

   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Make sure that MenuPaused and all the children under are turned on before playing.");

        Time.timeScale = 1;
        PostProcessVolume ppVolume = blurCamera.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;
        Menu.SetActive(false);
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
        if (pauseMenuOFF && Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0;
            script.LookEnabled = false;
            ppVolume.enabled = true;
            Menu.SetActive(true);
            PauseMenu.SetActive(true);
            PlayerHUD.SetActive(false);
            pauseMenuOFF = false;
            pauseMenuON = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (pauseMenuON && Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 1;
            script.LookEnabled = true;
            ppVolume.enabled = false;
            Menu.SetActive(false);
            PauseMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            PlayerHUD.SetActive(true);
            pauseMenuOFF = true;
            pauseMenuON = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //}


    }

    public void Resume()
    {
        Time.timeScale = 1;
        script.LookEnabled = true;
        PostProcessVolume ppVolume = blurCamera.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;
        Menu.SetActive(false);
        PauseMenu.SetActive(false);
        PlayerHUD.SetActive(true);
        pauseMenuOFF = true;
        pauseMenuON = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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




