using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinTrigger : MonoBehaviour
{
    /// <summary>
    /// load the next scene when the player get into the trigger
    /// </summary>
    [Header("Will load this scene index from the build menu when player enters trigger")]
    public int loadLevel = 2;
    [Tooltip("the panel to enable when we trigger this")]
    public GameObject messagePanel;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadScene());
    }
    
    IEnumerator LoadScene()
    {
        messagePanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(loadLevel);
        while (!loadSceneAsync.isDone)
        {
            yield return null;
        }
        messagePanel.SetActive(false);
    }


}
