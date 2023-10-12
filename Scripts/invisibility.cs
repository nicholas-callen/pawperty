using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibility : MonoBehaviour
{
    public SpriteRenderer sprite;
    public bool isPlayer = false;
    public float talkspeed = 4;

    float talkCooldown = 0;

    Color baseColor;
    Color invis;
    

    // Start is called before the first frame update
    void Start()
    {
        baseColor = sprite.color;
        invis = new Color(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.anyKey) talkCooldown = 2.0f;

        if(talkCooldown > 0 && isPlayer) {
            chatAnim();
        }
        else if (isPlayer) {
            sprite.color = invis;
        }
        else if (talkCooldown < 0.5f){
            chatAnim();
        }
        else if (Input.anyKey) {
            sprite.color = invis;
        }

        talkCooldown -= Time.deltaTime;
    }

    void chatAnim() {
        if(Mathf.Floor(Time.time * talkspeed) % 3 == 1) {
            sprite.color = invis;
        } else sprite.color = baseColor;

    }
}
