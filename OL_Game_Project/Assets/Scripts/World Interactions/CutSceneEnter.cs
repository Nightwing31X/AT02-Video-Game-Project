//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class CutSceneEnter : MonoBehaviour
//{
//    public GameObject thePlayer;
//    public GameObject playerHUD;
//    public GameObject playerCAM;
//    public GameObject cutsceneCAM;


//    public PlayerController cutsceneCHECK;
//    public int durationTIME; //# Can set how long the cutscene is


//    [SerializeField] private float lowtime, maxtime = 100;
//    [SerializeField] private float seconds = 20;
//    [SerializeField] private float howlong;
//    public Image skipBar;
//    private Coroutine recharge;



//    //    void OnTriggerEnter(Collider other)
//    public void cutsceneStart()
//    {
//        cutsceneCHECK.inCutscene = true;
//        Debug.Log(durationTIME);
//        this.gameObject.GetComponent<BoxCollider>().enabled = false;
//        thePlayer.GetComponentInChildren<PlayerController>().enabled = false;
//        thePlayer.GetComponentInChildren<TorchBehaviour>().enabled = false;
//        thePlayer.GetComponentInChildren<Footsteps>().enabled = false;
//        playerHUD.SetActive(false);
//        cutsceneCAM.SetActive(true);
//        playerCAM.SetActive(false);
//        StartCoroutine(FinishCut());
//    }

//    IEnumerator FinishCut()
//    {
//        yield return new WaitForSeconds(durationTIME);
//        playerCAM.SetActive(true);
//        playerHUD.SetActive(true);
//        thePlayer.GetComponentInChildren<PlayerController>().enabled = true;
//        thePlayer.GetComponentInChildren<TorchBehaviour>().enabled = true;
//        thePlayer.GetComponentInChildren<Footsteps>().enabled = true;
//        cutsceneCAM.SetActive(false);
//        cutsceneCHECK.inCutscene = false;
//    }


//    private void SkipCutscene()
//    {

//        if (lowtime > 0)
//        {
//            lowtime -= seconds * Time.deltaTime;
//            if (lowtime < 0)
//            {
//                lowtime = 0;
//            }
//            if (skipBar.fillAmount == 0)
//            {
//                Debug.Log("Skipped cutscene...");
//                playerCAM.SetActive(true);
//                playerHUD.SetActive(true);
//                thePlayer.GetComponentInChildren<PlayerController>().enabled = true;
//                thePlayer.GetComponentInChildren<TorchBehaviour>().enabled = true;
//                thePlayer.GetComponentInChildren<Footsteps>().enabled = true;
//                cutsceneCAM.SetActive(false);
//                cutsceneCHECK.inCutscene = false;
//            }
//            skipBar.fillAmount = lowtime / maxtime;
//        }
//        else
//        {
//            //Debug.Log(currentMovementSpeed);
//        }

//        if (recharge != null)
//        {
//            StopCoroutine(recharge);
//        }
//        recharge = StartCoroutine(Recharge());

//    }



//    //# Recharges the sprintBar - waits 1 second until it starts to recharge
//    private IEnumerator Recharge()
//    {
//        yield return new WaitForSeconds(1f);
//        //stamina += chargeRate / 10f;

//        lowtime = howlong;
//        skipBar.fillAmount = maxtime;


//        //while (lowtime < maxtime)
//        //{

//        //    lowtime += howlong / 10f;
//        //    //lowtime += howlong;
//        //    if (lowtime > maxtime)
//        //    {
//        //        lowtime = maxtime;
//        //    }
//        //    skipBar.fillAmount = lowtime / maxtime;
//        //    yield return new WaitForSeconds(.1f);
//        //}
//    }


//    // Start is called before the first frame update
//    void Awake()
//    {
//        cutsceneCAM.SetActive(false);
//    }

//    void Update()
//    {
//        //if (cutsceneCHECK.inCutscene && Input.GetButton("SkipCutscene"))
//        //{
//        if (cutsceneCHECK.inCutscene && Input.GetButton("SkipCutscene"))
//        {
//            SkipCutscene();
//            Debug.Log("Skip Active...");
//        }
//        //}
//    }
//}
