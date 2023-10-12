using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerPunch : MonoBehaviour
{
    public masterGameController gameController;


    // Paws
    public SpriteRenderer leftPaw;
    public SpriteRenderer rightPaw;
    public Color baseColor = new Color(1f,1f,1f,1f);
    public Color watchColor = new Color(1f,0.8f,0.8f,1f);
    public Color pressColor = new Color(0.5f,0.5f,0.5f,1f);
    public Color winColor = new Color(0.7f,0.7f,0.2f,1f);
    public Color lossColor = new Color(0.7f,0.2f,0.2f,1f);


    // Events
    public int numEvents = 10;
    public int numTriggered;

    private float maxResponseTime = 1.25f;
    private float minResponseTime = 0.650f;

    // Round Based Stuff
    public float difficulty;
    private float round;


    //Runtime Variables
    bool isLeftNext;
    bool isLost;
    bool isWon;
    int setUpState;
    float timeTilNext;
    float gracePeriod = 1f;
    float lossCountdown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<masterGameController>();
        setUpState = 1;
        isLost = false;
        isWon = false;
        leftPaw.color = baseColor;
        rightPaw.color = baseColor;
        int round = gameController.Rounds;
        difficulty = round;
    }

    // Update is called once per frame
    void Update()
    {   
        // Loss Screen
        if(isLost || timeTilNext < 0) {
            rightPaw.color = lossColor;
            leftPaw.color = lossColor;


            lossCountdown -= Time.deltaTime;

            // Trigger Events below
              gameController.LoadScene("Lose");

            return;
        }

        if(isWon) {
            rightPaw.color = winColor;
            leftPaw.color = winColor;

            gameController.IncreaseRound(1);
            gameController.LoadScene("Resting");
            return;
        }

        // Wait a sec before starting actual game
        if(gracePeriod > 0f) {
            gracePeriod -= Time.deltaTime;
            return;
        }

        if(setUpState == 1) {
            generateChoice();
            setUpState -= 1;
        }

        // Press Left and right
        triggerEvent(check());

        // Progress Time
        if(timeTilNext < getResponseTime() - 0.15f) resetPaws();
        
        timeTilNext -= Time.deltaTime;
    }

    void generateChoice() {
        int choice = (int)Mathf.Floor(Random.value * 2f);
        resetPaws();
        if(choice == 0) {
            loadLeft();
            isLeftNext = true;
            timeTilNext = getResponseTime();
        }
        else {
            loadRight();
            isLeftNext = false;
            timeTilNext = getResponseTime();
        }
    }


    // ADD LOSE CONDITIONS
    int check() {
        // 0 - Wrong
        // 1 - Right
        // 2 - No key of interest/Invalid Input
        // Check Left
        if(Input.inputString.Contains("a") && Input.inputString.Contains("d"))
            return 2;
        else if(Input.inputString.Contains("a")) {
            if(isLeftNext) return 1;
            isLost = true;
            return 0;
        }
        else if(Input.inputString.Contains("d")) {
            if(!isLeftNext) return 1;
            isLost = true;
            return 0;
        }
        return 2;
    }

    void triggerEvent(int val) {
        if(val == 2) return;
            // Trigger event on failure
        if(val == 0) {
            isLost = true;
            return;
        }   // Trigger event on success
        else if (val == 1) {
            numTriggered += 1;

            // Game Win
            if(numTriggered == numEvents) {
                isWon = true;
                return;
            }
            // Game Continues
            generateChoice();
        }
    }

    void loadLeft(){
        leftPaw.color = watchColor;
    }
    void loadRight(){
        rightPaw.color = watchColor;
    }

    void resetPaws(){
        leftPaw.color = baseColor;
        rightPaw.color = baseColor;
    }

    float getResponseTime() {
        return Mathf.Max(minResponseTime, maxResponseTime - 0.15f * difficulty);
    }
}
