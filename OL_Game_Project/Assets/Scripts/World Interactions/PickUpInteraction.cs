using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteraction : MonoBehaviour
{

    public GameObject TorchOnPlayer;

    private GameObject PickUpTorch;

    public void TorchPickUP()
    {
        PickUpTorch.SetActive(false);
        //this.gameObject.SetActive(false);
        TorchOnPlayer.SetActive(true);
    }


    //public GameObject PickUpText; //# Text Promp to pickup things

    // Start is called before the first frame update
    void Start()
    {
        //TorchOnPlayer.SetActive(false);
        //PickUpTorch = GameObject.FindWithTag("PickUp_Torch");
    }

    void Update()
    {
        //if (Input.GetButtonDown("Interaction"))
        //{
        //    if (PickUpTorch)
        //    {
        //        PickUpTorch.SetActive(false);
        //        //this.gameObject.SetActive(false);
        //        TorchOnPlayer.SetActive(true);
        //    }
        //    Debug.Log("Picked up");
        //}
    }



    //    private void OnTriggerEnter(Collider other)
    //    {
    //        PickUpText.SetActive(true);
    //    }

    //    private void OnTriggerStay(Collider other)
    //    {
    //        if (Input.GetButtonDown("Interaction"))
    //        {
    //            Debug.Log("Picked up");
    //            this.gameObject.SetActive(false);
    //            TorchOnPlayer.SetActive(true);
    //            //PickUpText.SetActive(false);
    //        }

    //        //if (other.gameObject.tag == "Player")
    //        //{
    //        //    Debug.Log("In Zone...");
    //        //PickUpText.SetActive(true);

    //        //if (Input.GetButtonDown("Interaction"))
    //        //{
    //        //    Debug.Log("Picked up");
    //        //    this.gameObject.SetActive(false);
    //        //    TorchOnPlayer.SetActive(true);
    //        //    //PickUpText.SetActive(false);
    //        //}
    //        //}
    //    }

    //    private void OnTriggerExit(Collider other)
    //    {
    //        PickUpText.SetActive(false); //# Make sure it is turned off when game starts
    //    }
}
