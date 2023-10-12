using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleTwist : MonoBehaviour
{
    public Rigidbody2D item;
    public float frequency = 1; 
    public float magnitude = 1;
    public float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Alternates movement based on even and odd seconds
        if (Mathf.Floor(Time.time * frequency + offset) % 2 == 0) {
            item.rotation += magnitude * Time.deltaTime * frequency;
        }
        if (Mathf.Floor(Time.time * frequency + offset) % 2 == 1) {
            item.rotation += -magnitude * Time.deltaTime * frequency;
        }
    }
}
