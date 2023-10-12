using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGaming : MonoBehaviour
{
    public masterGameController gameController;

    public string sceneToLoad;

    public void OnMouseDown()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(sceneToLoad);
        gameController = FindObjectOfType<masterGameController>();
        gameController.setRound();

    }
}