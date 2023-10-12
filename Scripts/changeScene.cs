using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public string sceneToLoad;

    public void OnMouseDown()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(sceneToLoad);
        string currentScene = SceneManager.GetActiveScene().name;
    }
}
