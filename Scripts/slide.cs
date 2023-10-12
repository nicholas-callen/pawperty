using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidein : MonoBehaviour
{
    public Rigidbody2D item;

    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float xMaxPos = 0f;
    public float xMinPos = 0f;
    public float yMaxPos = 0f;
    public float yMinPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = item.position.x;
        float tempY = item.position.y;

        if(item.position.x > xMinPos && item.position.x < xMaxPos ) 
            tempX += xSpeed * Time.deltaTime;
        if(item.position.y > yMinPos && item.position.y < yMaxPos ) 
            tempY += ySpeed * Time.deltaTime;
        
        item.position = new Vector2(tempX, tempY);
    }
}
