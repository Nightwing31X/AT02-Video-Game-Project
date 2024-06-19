using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Prompts : MonoBehaviour
{

    public GameObject TextOBJ;
    public Text SubTxt;
    public float SecondsOfReading;
    [Tooltip("Select if you wish to vanish object(s)")]
    public bool ObjVanish;
    public bool VanishSelf;
    [Tooltip("Select if you wish to appear object(s)")]
    public bool ObjAppear;
    public bool showText;

    [SerializeField][TextArea] private string textContent;

    public GameObject[] ObjsToVanish;
    public GameObject[] ObjsToAppear;

    private GameObject[] arrayOfObjs;
    public int numberOfObjects;

    public bool SplitObjs;


    //private float current = 0;
    bool textOn;


    // Start is called before the first frame update
    void Start()
    {
        //TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //SubTxt.text = string.Format(textContent);
        TextOBJ.SetActive(false);
        //ObjsToAppear[].GetComponents<MeshCollider>();
    }

    void Update()
    {
        if (textOn)
        {
            TextOBJ.SetActive(true);
        }
    }

    public void TextPrompt()
    {
        if (showText)
        {
            textOn = true;
        }
        StartCoroutine(ShowPromptText());
    }

    public void VanishObject()
    {
        if (ObjVanish)
        {
            StartCoroutine(VanishAllObjects());
        }
    }

    public void AppearObject()
    {
        if (!SplitObjs)
        {
            if (ObjAppear)
            {
                StartCoroutine(AppearAllObjects());
            }
        }
        else
        {
            arrayOfObjs = ObjsToAppear;
            StartCoroutine(HalfObjects(numberOfObjects));
        }
    }

    private IEnumerator ShowPromptText()
    {
        if (showText)
        {
            SubTxt.text = string.Format(textContent);
            //TextOBJ.SetActive(false);
            Debug.Log("Showing...");
            //yield return new WaitForSeconds(6f);
            if (SecondsOfReading == 0)
            {
                SecondsOfReading = 6f;
            }
            yield return new WaitForSeconds(SecondsOfReading);
            textOn = false;
            TextOBJ.SetActive(false);
            Debug.Log("Showing...");
        }

        if (SplitObjs)
        {
            if (ObjVanish)
            {
                arrayOfObjs = ObjsToVanish;
            }
            else
            {
                arrayOfObjs = ObjsToAppear;
            }
            StartCoroutine(HalfObjects(numberOfObjects));
        }
        else
        {
            if (ObjVanish)
            {
                StartCoroutine(VanishAllObjects());
            }

            if (ObjAppear)
            {
                StartCoroutine(AppearAllObjects());
            }
        }
    }

    private IEnumerator VanishAllObjects()
    {
        yield return new WaitForSeconds(.5f);

        int totalObjects = ObjsToVanish.Length;
        List<int> indicesVanished = new List<int>();

        while (indicesVanished.Count < totalObjects)
        {
            int i = Random.Range(0, ObjsToVanish.Length);

            // Ensure the object at index i hasn't been deactivated already
            if (!indicesVanished.Contains(i))
            {
                if (!VanishSelf)
                {
                    Debug.Log("Normal thing");
                    ObjsToVanish[i].SetActive(false);
                }
                else
                {
                    Debug.Log("Delay is happening...");
                    StartCoroutine(Delay());
                    //if (ObjVanish) 
                    if (ObjsToVanish.Length > 1)
                    {
                        ObjsToVanish[i].SetActive(false);
                    }
                }
                indicesVanished.Add(i);

                // Adds a small delay to see the objects vanishing one by one
                yield return new WaitForSeconds(1f);
            }

            // If you don't want any delay, use yield return null to wait for the next frame
            yield return null;
        }
    }


    // Make Objects appear
    private IEnumerator AppearAllObjects()
    {
        yield return new WaitForSeconds(.5f);

        int totalObjects = ObjsToAppear.Length;
        List<int> indicesAppear = new List<int>();

        while (indicesAppear.Count < totalObjects)
        {
            int i = Random.Range(0, ObjsToAppear.Length);

            // Ensure the object at index i hasn't been deactivated already
            if (!indicesAppear.Contains(i))
            {
                ObjsToAppear[i].SetActive(true);
                indicesAppear.Add(i);
            }
            yield return null;
        }
    }


    private IEnumerator HalfObjects(int numberOfObjects)
    {
        yield return new WaitForSeconds(.5f);

        int totalObjects = arrayOfObjs.Length;
        List<int> indicesAppear = new List<int>();

        while (indicesAppear.Count < numberOfObjects)
        {
            int i = Random.Range(0, totalObjects);

            // Ensure the object at index i hasn't been deactivated already
            if (!indicesAppear.Contains(i))
            {
                Debug.Log("Show Batteries...");
                arrayOfObjs[i].SetActive(true);
                indicesAppear.Add(i);
            }
            yield return null;
        }

        // Set the rest of the items to inactive
        for (int i = 0; i < totalObjects; i++)
        {
            if (!indicesAppear.Contains(i))
            {
                arrayOfObjs[i].SetActive(false);
            }
        }
    }




    IEnumerator Delay()
    {
        this.gameObject.transform.position = new Vector3(0.0f, 50.0f, 0.0f); //# Moves the object intertacted with upwards (to hide & allow audio to play)
        yield return new WaitForSeconds(SecondsOfReading); //# Waits 3 seconds (thats how long the audio is)
        this.gameObject.SetActive(false); //# Then deactives the object
    }

}
