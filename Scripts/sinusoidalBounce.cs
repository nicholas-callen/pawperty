using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinusoidalBounce : MonoBehaviour
{
    public Rigidbody2D item;
    public SpriteRenderer sprite;
    public float Xspeed;
    public float Yspeed;
    public float Xmagnitude;
    public float Ymagnitude;
    float currBrightness;
    float baseXPos;
    float baseYPos;

    // Start is called before the first frame update
    void Start()
    {
        baseXPos = item.position.x;
        baseYPos = item.position.y;
        currBrightness = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        item.position = new Vector2(baseXPos + Mathf.Sin(Xspeed * Time.time) * Xmagnitude,
                baseYPos + Mathf.Cos(Yspeed * Time.time) * Ymagnitude);

        sprite.color = new Color(currBrightness, currBrightness, currBrightness, 1f);


        if(Mathf.Cos(Xspeed * Time.time) > 0) {
            sprite.sortingOrder = 3;
            if(currBrightness < 1f) currBrightness += 0.01f;
        }
        else {
            sprite.sortingOrder = 0;
            if(currBrightness > 0.4f) currBrightness -= 0.01f;
        }
        
    }
}
