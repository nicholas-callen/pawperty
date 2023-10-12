using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public masterGameController gameController;

    public SpriteRenderer up;       // 1
    public SpriteRenderer right;    // 2
    public SpriteRenderer left;     // 3
    public SpriteRenderer down;     // 4
    public Color highlightColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    public Color baseColor = new Color(1f, 1f, 1f, 1f);
    public Color watchColor = new Color(0.75f, 0.75f, 0.75f, 1f);

    public float movement = 1f;
    public float period = 0.5f;
    public float baseperiod = 0.5f;


    float resetTime;
    float countdown;
    public static float watchCountdown;
    float wrongCountdown;
    int watchIndex;
    public float maxWatchTime = 0.8f;
    float timeAtStart;
    int correct;
    bool wrong;

    public int maxRounds = 6; 
    int wonRounds = 0;
    public int lives = 3;

    public int universalDifficulty;

    // Difficulty adds length to the array
    public float startLength = 5;
    int difficulty;
    int playIndex;
    bool untriggered = true;
    List<int> memory = new List<int>();
    List<int> pattern = new List<int>();
    /*
        0 - W, 1 - A, 2 - S, 3 - D
    */

    

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<masterGameController>();
        int round = gameController.Rounds;
        universalDifficulty = round;

        resetTime = period;
        difficulty = 0;
        wrong = false;
        wrongCountdown = 1f;
        period = Mathf.Max(baseperiod - (float)universalDifficulty * 0.05f, 0.20f);

        resetState();
    }

    // Update is called once per frame
    void Update()
    {
        if(wonRounds == maxRounds) {
            // Insert Code for winning a round

            gameController.LoadScene("Hammer");
            // resetColors(new Color(0.3f, 1.0f, 0.3f, 1f));
            // return;
        }

        if(lives <= 0) {
            // Insert Code for failing


            gameController.LoadScene("Lose");
            // resetColors(new Color(1.0f, 0.3f, 0.3f, 1f));
            // return;
        }

        markWrong();
        if(wrongCountdown > 0f) {
            wrongCountdown -= Time.deltaTime;
            return;
        }

        // Check if game won
        if(correct >= startLength + difficulty) {
            upDiff();
            return;
        }


        // Doesnt start counting down until grace period is over
        /*********************************

                 OBSERVING STAGE

        **********************************/
        if(watchIndex < memory.Count) {
            watchCountdown -= Time.deltaTime;

            switch(memory[watchIndex]) {
                case 0: // W
                    resetColors(watchColor);
                    up.color = highlightColor;
                    break;
                case 1: // A
                    resetColors(watchColor);
                    left.color = highlightColor;
                    break;
                case 2: // S
                    resetColors(watchColor);
                    down.color = highlightColor;
                    break;
                case 3: // D
                    resetColors(watchColor);
                    right.color = highlightColor;
                    break;
            }

            if(watchCountdown < 0.1f) {
                resetColors(watchColor);
                countdown = 5f + difficulty * 2f;
            }
            if(watchCountdown < 0f) {
                watchCountdown = maxWatchTime;
                watchIndex += 1;

                if(watchIndex == startLength + difficulty) {
                    resetColors(baseColor);
                }
            }

            return;
        }
        /*********************************

                 RESPONDING STAGE
                 
        **********************************/

        countdown -= Time.deltaTime;

        // If corresponding key is pressed
        for(int i = 0; i < Input.inputString.Length; i++) {
            char currChar = Input.inputString[i];
            switch(currChar) {
                case 'w':
                    pattern.Add(0);
                    break;
                case 'a':
                    pattern.Add(1);
                    break;
                case 's':
                    pattern.Add(2);
                    break;
                case 'd':
                    pattern.Add(3);
                    break;
            }
        }

        if(checkMatch()) {
            upDiff();
        }

        // Reset Index when you get to the end successfully
        if (countdown < 0f){
            /* TRIGGER IF FAILED */
            lives -= 1;
            resetState();
        }

    }

    // Generates a play order of (size)
    void randomFill() {
        List<int> playlist = new List<int>();
        for(int i = 0; i < startLength + difficulty; i++) {
            playlist.Add((int)Mathf.Floor(Random.value * 4.0f));
        }
    
        memory = playlist;
    }
    
    void resetColors(Color color) {
        up.color = color;
        right.color = color;
        down.color = color;
        left.color = color;
    }

    void resetState() {
        watchIndex = 0;
        playIndex = 0;
        countdown = Mathf.Floor(period * Mathf.Max(difficulty * 1f, 1.0f));
        watchCountdown = maxWatchTime;
        correct = 0;
        untriggered = true;
        pattern.Clear();

        resetColors(baseColor);
        randomFill();
    }

    string toKey(int x) {
        switch(x) {
            case 0: return "w";
            case 1: return "a";
            case 2: return "s";
            case 4: return "d";
        }
        return null;
    }

    void upDiff() {
        highlightColor = new Color(Mathf.Max(Random.value, 0.4f), Mathf.Max(Random.value, 0.4f),Mathf.Max(Random.value, 0.4f), 1f);
        difficulty += 1;
        resetState();
    }

    void markWrong() {
        if(!wrong) return;

        if (wrongCountdown > 0) { 
            resetColors(new Color(1f, 0.1f, 0.1f, 1f));
            wrongCountdown -= Time.deltaTime;
            return;
        }

        resetColors(baseColor);
        wrong = false;
    }

    //Checks if the lists elements match
    private bool checkMatch() {
        if (pattern.Count < memory.Count) return false;

        for(int i = 0; i < memory.Count; i++) {
            if(pattern[i] != memory[i]) {
                resetState();
                wrongCountdown = 0.5f;
                lives -= 1;
                wrong = true;
                return false;
            }
        }

        wonRounds += 1;
        return true;
    }
}
