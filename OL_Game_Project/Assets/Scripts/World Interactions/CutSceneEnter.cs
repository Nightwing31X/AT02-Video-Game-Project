using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject playerHUD;
    public GameObject playerCAM;
    public GameObject cutsceneCAM;


//    void OnTriggerEnter(Collider other)
    public void cutsceneStart()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponentInChildren<PlayerController>().enabled = false;
        thePlayer.GetComponentInChildren<TorchBehaviour>().enabled = false;
        thePlayer.GetComponentInChildren<Footsteps>().enabled = false;
        playerHUD.SetActive(false);
        cutsceneCAM.SetActive(true);
        playerCAM.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(4);
        playerCAM.SetActive(true);
        playerHUD.SetActive(true);
        thePlayer.GetComponentInChildren<PlayerController>().enabled = true;
        thePlayer.GetComponentInChildren<TorchBehaviour>().enabled = true;
        thePlayer.GetComponentInChildren<Footsteps>().enabled = true;
        cutsceneCAM.SetActive(false);
    }


    // Start is called before the first frame update
    void Awake()
    {
        cutsceneCAM.SetActive(false);
    }
}
