using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;
    public GameObject background;
    public GameObject LossObj;
    public GameObject LossOverlay;

    void Awake()
    {
        LossObj.SetActive(false);
    }
    
    void Start()
    {
        background.SetActive(false);
        TimerOn = false;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                LossOverlay.SetActive(true);
                LossObj.SetActive(true);
            }
        }
    }

    public void startTimer()
    {
        Debug.Log("Start timer!");
        TimerOn = true;
        background.SetActive(true);
    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
