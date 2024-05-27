using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteraction : MonoBehaviour
{

    public GameObject PickUpText;
    public GameObject TorchOnPlayer;


    // Start is called before the first frame update
    void Start()
    {
        //TorchOnPlayer.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            //TorchOnPlayer.SetActive(true);
            Debug.Log("Picked up");
        }
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PickUpText.SetActive(true);

    //        if (Input.GetButtonDown("Interaction"))
    //        {
    //            this.gameObject.SetActive(false);
    //            TorchOnPlayer.SetActive(true);
    //            PickUpText.SetActive(false);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    PickUpText.SetActive(false); //# Make sure it is turned off when game starts
    //}
}
