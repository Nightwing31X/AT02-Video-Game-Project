using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PickUpInteraction : MonoBehaviour
{

    private Renderer RenderTorch;

    private GameObject TorchOnPlayer;
    public GameObject ParentBatteries;

    public GameObject keyInINV;
    public int ActiveBatteries;
    public GameObject[] BatteriesToAppear;
    private int Count;

    public TorchBehaviour batteryCHECK;



    // Start is called before the first frame update
    void Start()
    {
        TorchOnPlayer = GameObject.FindGameObjectWithTag("TorchOnPlayer");
        RenderTorch = TorchOnPlayer.GetComponent<Renderer>();

        if (ParentBatteries)
        {
            ParentBatteries.SetActive(false);
        }

        if (ActiveBatteries > BatteriesToAppear.Length)
        {
            Debug.Log("All Batteries will spawn...");
        }
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

    public void PickUP_Battery()
    {
        //if (batteryCHECK.currentcharge > batteryCHECK.MAXcharge)
        if (batteryCHECK.MAXcharge > batteryCHECK.currentcharge && batteryCHECK.currentcharge > 0)
        {
            StartCoroutine(Delay());
        }
    }
    public void PickUP_Key()
    {
        Debug.Log("Picked up key...");
        keyInINV.SetActive(true);
        StartCoroutine(Delay());
    }

    public void SpawnBatteries()
    {
        StartCoroutine(BatteriesAppear(ActiveBatteries));
    }

    // Make Objects appear
    // private IEnumerator BatteriesAppear()
    // {
    //     yield return new WaitForSeconds(.5f);

    //     int totalObjects = BatteriesToAppear.Length;
    //     List<int> indicesAppear = new List<int>();

    //     while (indicesAppear.Count < totalObjects)
    //     {
    //         int i = Random.Range(0, BatteriesToAppear.Length);

    //         // Ensure the object at index i hasn't been deactivated already
    //         if (!indicesAppear.Contains(i))
    //         {
    //             Debug.Log("Show Batteries...");
    //             BatteriesToAppear[i].SetActive(true);
    //             indicesAppear.Add(i);

    //             //yield return new WaitForSeconds(1f);
    //         }
    //         yield return null;
    //     }
    // }


    private IEnumerator BatteriesAppear(int numberToActivate)
    {
        yield return new WaitForSeconds(.5f);

        int totalObjects = BatteriesToAppear.Length;
        List<int> indicesAppear = new List<int>();

        while (indicesAppear.Count < numberToActivate)
        {
            int i = Random.Range(0, totalObjects);

            // Ensure the object at index i hasn't been deactivated already
            if (!indicesAppear.Contains(i))
            {
                Debug.Log("Show Batteries...");
                BatteriesToAppear[i].SetActive(true);
                indicesAppear.Add(i);
            }
            yield return null;
        }

        // Set the rest of the items to inactive
        for (int i = 0; i < totalObjects; i++)
        {
            if (!indicesAppear.Contains(i))
            {
                BatteriesToAppear[i].SetActive(false);
            }
        }
        ParentBatteries.SetActive(true);
    }
}

