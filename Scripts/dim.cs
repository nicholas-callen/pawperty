using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dim : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float variance = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float colorTime = Mathf.Min(Mathf.Max(Mathf.Cos(Time.time) * variance + 1f - variance, 0f), 1f);
        sprite.color = new Color(colorTime, colorTime, colorTime, 1f);
    }
}
