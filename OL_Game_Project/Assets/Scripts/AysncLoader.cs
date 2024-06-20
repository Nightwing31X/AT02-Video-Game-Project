using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class AysncLoader : MonoBehaviour
{  
    public GameObject loadingScreen;
    public Image loadingBarFill;
    public TMP_Text progressText;
    public string sceneToLoad;



    void Awake()
    {
        loadingScreen.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    // public void LoadScene(string sceneTitle)
    // {
    //     StartCoroutine(LoadSyncAsync(sceneTitle));
    // }

    // IEnumerator LoadSyncAsync(string sceneTitle)
    // {

    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneTitle);

    //     loadingScreen.SetActive(true);


    //     while (!operation.isDone)
    //     {
    //         float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

    //         loadingBarFill.fillAmount = progressValue;
    //         progressText.text = progressValue * 100f + "%";

    //         yield return null;
    //     }
    // }
}
