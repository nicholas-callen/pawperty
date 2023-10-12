using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBounce : MonoBehaviour
{
    public Rigidbody2D item;
    public float frequency = 1;
    public float XMagnitude = 0;
    public float YMagnitude = 0;

    Vector2 velocity;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
        velocity = new Vector2(XMagnitude, YMagnitude);
        offset = Random.Range(0.7f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Alternates movement based on even and odd seconds
        if (Mathf.Floor(Time.time * frequency * offset) % 2 == 0) {
            item.MovePosition(item.position + velocity * Time.deltaTime * frequency * offset);
        }
        if (Mathf.Floor(Time.time * frequency * offset) % 2 == 1) {
            item.MovePosition(item.position + velocity * Time.deltaTime * -1.0f * frequency * offset);
        }
    }
}
