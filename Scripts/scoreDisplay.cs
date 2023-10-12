using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDisplay : MonoBehaviour
{
    public static scoreDisplay Instance { get; private set; }
    public masterGameController gameController;
    public TMP_Text score;

    private void Start()
    {
        gameController = FindObjectOfType<masterGameController>();

    }

    private void Update()
    {
        score.text = gameController.Rounds.ToString();
    }

}
