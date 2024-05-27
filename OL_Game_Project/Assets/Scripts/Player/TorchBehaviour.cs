using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TorchBehaviour : MonoBehaviour
{
    public GameObject Torch; //# Rereference to the Model
    public GameObject Light; //# Rereference to the Light Source
    public GameObject Crosshair; //# Rereference to the Crosshair Image


    //public AudioSource turnOn;
    //public AudioSource turnOff;

    public bool on;
    public bool off;



    // Start is called before the first frame update
    void Start()
    {
        if (Torch.activeInHierarchy == true)
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
        if (Torch.activeInHierarchy == true)
        {
            Crosshair.SetActive(false);
            if (off && Input.GetButtonDown("Flashlight_toggle"))
            {
                Light.SetActive(true);
                //turnOn.Play(); 
                off = false;
                on = true;
            }
            else if (on && Input.GetButtonDown("Flashlight_toggle"))
            {
                Light.SetActive(false);
                //turnOff.Play(); 
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
