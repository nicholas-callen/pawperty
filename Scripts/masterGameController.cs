using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class masterGameController : MonoBehaviour
{
    public static masterGameController Instance { get; private set; }

    public int Rounds{ get; set; } = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setRound()
    {
        Rounds = 1;
    }


    public void IncreaseRound(int rounds)
    {
        Rounds += 1;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
