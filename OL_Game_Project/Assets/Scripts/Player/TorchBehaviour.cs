using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TorchBehaviour : MonoBehaviour
{

    private Renderer RenderTorch;

    public GameObject Torch; //# Rereference to the Model
    public GameObject Light; //# Rereference to the Light Source
    public GameObject Crosshair; //# Rereference to the Crosshair Image


    public AudioSource turnOn;
    public AudioSource turnOff;

    private bool on;
    private bool off;


    void Awake()
    {
        RenderTorch = Torch.GetComponent<Renderer>();
        RenderTorch.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (RenderTorch.enabled == true)
        {
            Crosshair.SetActive(false);
            off = true;
            Light.SetActive(false);
        }
        else
        {
            Crosshair.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PauseGame>().pauseMenuOFF)
        {
            if (RenderTorch.enabled == true)
            {
                Crosshair.SetActive(false);
                if (off && Input.GetButtonDown("Flashlight_toggle"))
                {
                    Light.SetActive(true);
                    turnOn.Play(); 
                    off = false;
                    on = true;
                }
                else if (on && Input.GetButtonDown("Flashlight_toggle"))
                {
                    Light.SetActive(false);
                    turnOff.Play(); 
                    off = true;
                    on = false;
                }
            }
            else
            {
                Crosshair.SetActive(true);
                Light.SetActive(false);
                off = true;
                on = false;
            }
        }
    }
}



//POSITION
// x = 0.5
// y = -0.3
// z = 0.5

// ROTATION
// x = 5.25
// y = 171
// z = 0