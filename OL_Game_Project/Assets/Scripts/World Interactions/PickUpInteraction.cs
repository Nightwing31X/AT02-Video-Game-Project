using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PickUpInteraction : MonoBehaviour
{

    private Renderer RenderTorch;

    private GameObject TorchOnPlayer;

    public GameObject keyInINV;


    // Start is called before the first frame update
    void Start()
    {
        TorchOnPlayer = GameObject.FindGameObjectWithTag("TorchOnPlayer");
        RenderTorch = TorchOnPlayer.GetComponent<Renderer>();
    }


    IEnumerator Delay() 
    {
        this.gameObject.transform.position = new Vector3(0.0f, 50.0f, 0.0f); //# Moves the object intertacted with upwards (to hide & allow audio to play)
        yield return new WaitForSeconds(5); //# Waits 3 seconds (thats how long the audio is)
        this.gameObject.SetActive(false); //# Then deactives the object
    }


    public void PickUP_Torch()
    {
        RenderTorch.enabled = true;
        StartCoroutine(Delay());
    }

    public void PickUP_Key()
    {
        Debug.Log("Picked up key...");
        keyInINV.SetActive(true);
        StartCoroutine(Delay());
    }

    void Update()
    {

    }
}

