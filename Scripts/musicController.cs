using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicController : MonoBehaviour
{
    public AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("audio source found");
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.loop = true;
        musicPlayer.Play();


        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
