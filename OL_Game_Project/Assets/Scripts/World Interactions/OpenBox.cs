using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    public Animator boxANIM;
    public GameObject boxOBJ;
    public GameObject keyOBJNeeded;
    public GameObject KeyMissingText;

    public bool isOpen;

    public AudioSource Unlocked;
    public AudioSource Locked;

    // Start is called before the first frame update
    void Start()
    {
        KeyMissingText.SetActive(false);
        keyOBJNeeded.SetActive(false);

        //isOpen = false;
    }

    IEnumerator Delay()
    {
        Locked.Play();
        KeyMissingText.SetActive(true);
        yield return new WaitForSeconds(1f); //# Waits 3 seconds (thats how long the audio is)
        KeyMissingText.SetActive(false);
    }


    public void openBOX()
    {
        if (keyOBJNeeded.activeInHierarchy == true && Input.GetButtonDown("Interaction"))
        {
            Unlocked.Play();
            keyOBJNeeded.SetActive(false);
            boxANIM.SetBool("open", true);
            KeyMissingText.SetActive(false);
            isOpen = true;
        }
        else if (keyOBJNeeded.activeInHierarchy == false && Input.GetButtonDown("Interaction"))
        {
            StartCoroutine(Delay());
        }


            if (isOpen)
        {
            boxOBJ.GetComponent<OpenBox>().enabled = false;
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
            boxOBJ.layer = LayerIgnoreRaycast;
            Debug.Log("Current layer: " + boxOBJ.layer);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
