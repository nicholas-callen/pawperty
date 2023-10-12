using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressColorSwitch : MonoBehaviour
{
    public SpriteRenderer sprite;
    public string key;
    public float r = 120f;
    public float g = 120f;
    public float b = 120f;

    Color pressColor;
    Color baseColor;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        baseColor = new Color(1f, 1f, 1f, 1f);
        pressColor = new Color(r/255f, g/255f, b/255f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
            sprite.color = pressColor;
        if (Input.GetKeyUp(key))
            sprite.color = baseColor;
    }
}
