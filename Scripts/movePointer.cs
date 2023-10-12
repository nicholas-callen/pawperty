using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover: MonoBehaviour
{
    private float moveSpeed;
    private float positiveSpeed;
    private float negativeSpeed;
    private float round;

    public masterGameController gameController;

    

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<masterGameController>();
        int round = gameController.Rounds;
        moveSpeed = round * 5;
        positiveSpeed = round * 5;
        negativeSpeed = round * -5;
        Debug.Log(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        moverFunction();
    }

    void moverFunction()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        float position = transform.position.x;
        if (position >= 5)
        {
            moveSpeed = negativeSpeed;

        }
        if (position <= -5)
        {
            moveSpeed = positiveSpeed;
        }
    }


}
