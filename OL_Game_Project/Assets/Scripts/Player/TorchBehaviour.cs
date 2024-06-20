using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


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

    [SerializeField] private float TorchDuration = 10;
    [SerializeField] private float TorchDurationSET;
    public float MAXcharge = 3;
    public float currentcharge = 1;
    private float previousCharge = -1;


    public GameObject TorchArea;
    public Image TorchDurationIMG;
    public Image TorchOffIMG;
    public RawImage[] BatteryIcons;



    void Awake()
    {
        RenderTorch = Torch.GetComponent<Renderer>();
        RenderTorch.enabled = false;
        TorchArea.SetActive(false);
        TorchDurationSET = TorchDuration;
    }


    // Start is called before the first frame update
    // void Start()
    // {
    //     if (charge >= 4)
    //     {
    //         Debug.Log("Charge can only be a max of 3...");
    //         charge = 3;
    //     }
    //     else if (charge == 0)
    //     {
    //         Debug.Log("Charge has started at zero...");
    //     }
    // }


    // Update is called once per frame
    void Update()
    {
        if (RenderTorch.enabled == true)
        {
            if (currentcharge != previousCharge)
            {
                //if (RenderTorch.enabled == true)
                //{
                TorchArea.SetActive(true);
                for (int i = 0; i < BatteryIcons.Length; i++)
                {
                    Debug.Log(i < currentcharge);
                    BatteryIcons[i].GetComponent<RawImage>().enabled = (i < currentcharge);
                }
                previousCharge = currentcharge;
                //}
                Debug.Log("TorchBehaviour...1");
            }

            if (GameObject.Find("Player").GetComponent<PauseGame>().pauseMenuOFF)
            {
                // if (currentcharge > 0)
                // {
                    // if (RenderTorch.enabled == true)
                    // {
                        //Crosshair.SetActive(false);
                        
                    if (off && Input.GetButtonDown("Flashlight_toggle"))
                    {
                        if (currentcharge > 0)
                        {
                            Light.SetActive(true);
                            turnOn.Play();
                            off = false;
                            on = true;
                            // TorchDurationIMG.enabled = true;
                            TorchOffIMG.enabled = false;
                        }
                    }
                    else if (on && Input.GetButtonDown("Flashlight_toggle"))
                    {
                        Light.SetActive(false);
                        turnOff.Play();
                        off = true;
                        on = false;
                        TorchOffIMG.enabled = true;
                    }
                    // }
                    // else
                    // {
                    //     //Crosshair.SetActive(true);
                    //     Light.SetActive(false);
                    //     off = true;
                    //     on = false;
                    // }
                    Debug.Log("TorchBehaviour...2");
                //}
            }

            if (on && currentcharge > 0)
            {
                if (TorchDuration > 0)
                {
                    TorchDuration -= Time.deltaTime;
                    TorchDurationIMG.fillAmount = TorchDuration/TorchDurationSET;
                    updateTimer(TorchDuration);

                }
                else
                {
                    Debug.Log("Time is UP!");
                    TorchDuration = TorchDurationSET;
                    TorchOffIMG.enabled = true;
                    Light.SetActive(false);
                    turnOff.Play();
                    off = true;
                    on = false;
                    currentcharge = currentcharge - 1;
                }
                Debug.Log("TorchBehaviour...3");
            }
            Debug.Log("TorchBehaviour...4");
        }
        else
        {
            //Crosshair.SetActive(true);
            Light.SetActive(false);
            off = true;
            on = false;
        }
        // if (currentcharge == 0)
        // {

        // }

    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        //TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Add_Battery()
    {
        // if (MAXcharge > currentcharge && currentcharge > 0)
        // //if (MAXcharge > currentcharge && currentcharge > 0)
        // {
        if (currentcharge < MAXcharge)
        {
            //Debug.Log("Added the value");
            currentcharge += 1;
        }
        Debug.Log(currentcharge);
        //}

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