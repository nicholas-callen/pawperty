using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class checkIfHit : MonoBehaviour
{
    private catAnimator catMessage;
    private evilAnimator evilMessage;
    public GameObject target;
    public GameObject mover;
    public int lives = 1;

    public void SetReference(GameObject reference)
    {
        target = reference;
    }
    // Start is called before the first frame update
    void Start()
    {
        //these two lines set cat as the object to be animated
        GameObject catInGame = GameObject.Find("cat");
        catMessage = catInGame.GetComponent<catAnimator>();

        GameObject evilInGame = GameObject.Find("evilHammer");
        evilMessage = evilInGame.GetComponent<evilAnimator>();



        mover = GameObject.Find("mover");
        SetReference(target);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("still getting called");
        if (Input.GetKeyDown(KeyCode.Space) && lives == 1)
        {
            if ((mover.transform.position.x) >= target.transform.position.x - 0.75f
            && (mover.transform.position.x) <= target.transform.position.x + 0.75f)
            {
                Debug.Log("WINNER WINNER CHICKEN DINNER");
                evilMessage.startDeath();
                catMessage.startBonk();
                lives = 0;

            }
            else
            {
                lives = 0;
                evilMessage.startKill();
            }
        }
    }
}
