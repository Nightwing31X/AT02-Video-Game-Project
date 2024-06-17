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
    //public GameObject Crosshair; //# Rereference to the Crosshair Image


    public AudioSource turnOn;
    public AudioSource turnOff;

    private bool on;
    private bool off;

    public float TorchDuration;
    public float charge;
    private float newcharge;




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
            //Crosshair.SetActive(false);
            off = true;
            Light.SetActive(false);
        }
        else
        {
            //Crosshair.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PauseGame>().pauseMenuOFF)
        {
            if (charge > 0)
            {
                if (RenderTorch.enabled == true)
                {
                    //Crosshair.SetActive(false);
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
                    //Crosshair.SetActive(true);
                    Light.SetActive(false);
                    off = true;
                    on = false;
                }
            }
        }

        if (on && charge > 0)
        {
            if (TorchDuration > 0)
            {
                TorchDuration -= Time.deltaTime;
                updateTimer(TorchDuration);
            }
            else
            {
                Debug.Log("Time is UP!");
                TorchDuration = 5;
                Light.SetActive(false);
                turnOff.Play();
                off = true;
                on = false;
                newcharge = charge - 1;
                charge = newcharge;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        //TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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