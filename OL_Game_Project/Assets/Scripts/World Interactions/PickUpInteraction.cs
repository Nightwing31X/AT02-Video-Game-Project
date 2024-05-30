using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PickUpInteraction : MonoBehaviour
{

    private Renderer RenderTorch;

    private GameObject PickUpTorch;


    // Start is called before the first frame update
    void Start()
    {
        PickUpTorch = GameObject.FindGameObjectWithTag("PickUp_Torch");
        RenderTorch = PickUpTorch.GetComponent<Renderer>();
    }


    IEnumerator Delay() 
    {
        this.gameObject.transform.position = new Vector3(0.0f, 50.0f, 0.0f); //# Moves the object intertacted with upwards (to hide & allow audio to play)
        yield return new WaitForSeconds(3); //# Waits 3 seconds (thats how long the audio is)
        this.gameObject.SetActive(false); //# Then deactives the object
    }


    public void PickUP_Torch()
    {
        RenderTorch.enabled = true;
        StartCoroutine(Delay());
    }
  
    void Update()
    {

    }
}

