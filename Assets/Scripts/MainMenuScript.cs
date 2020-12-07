using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    /// <summary>
    /// Activate load main level from button and do it async
    /// </summary>
    public Image loadingBarImage;
    private bool loading = false;
    public GameObject loadingBarPanel;
    public GameObject playButton;

    private void Start()
    {
        //disable the button
        playButton.SetActive(true);
        //enable the loading bar
        loadingBarPanel.SetActive(false);
    }


    public void PlayGame()
    {
        if (!loading)
        {
            //disable the button
            playButton.SetActive(false);
            //enable the loading bar
            loadingBarPanel.SetActive(true);
            loading = true;
            StartCoroutine(LoadGameLevel());
        }
    }
    
    IEnumerator LoadGameLevel()
    {
        //will load gameLevel at index 1 in the buildsettings
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(1);
        while (!asyncLoadScene.isDone)
        {
            loadingBarImage.fillAmount = asyncLoadScene.progress;
            yield return null;
        }
    }



}
