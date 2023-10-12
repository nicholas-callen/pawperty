using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilAnimator : MonoBehaviour
{
    public masterGameController gameController;

    public Animator animator;
    public float rotationSpeed = 80.0f;
    public float moveSpeed = 10.0f;
    //isDead=0 is alive =1 is dead
    private int isDead = 0;
    public float resetPositionX = 11.0f;

    //method to tell sprite to fly off screen
    public void startDeath()
    {
        Debug.Log("Spin about to start");

        //time before animation starts playing, for me 0.3 seconds was good
        Invoke("death", 0.3f);
    }

    private void death()
    {
        isDead = 1;
    }

    //method to kill player cat if you lose the minigame
    public void startKill()
    {
        Debug.Log("Kill about to start");
        animator.Play("catPounced", 0, 0f);
        transform.position = new Vector3(1f, -1f, 0f);
        animator.SetTrigger("enemyIdle");
        Invoke("moveBack2", 2.0f);
        StartCoroutine(waiter());
    }

    private void moveBack2()
    {
        transform.position = new Vector3(4.0f, -1.8f, 0f);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.5f);
        gameController.LoadScene("Lose");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<masterGameController>();

        isDead = 0;
        animator = GetComponent<Animator>();
        transform.position = new Vector3(4.0f, -1.8f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float currentPositionX = transform.position.x;
        if (currentPositionX > resetPositionX)
        {
            isDead = 0;
            transform.position = new Vector3(50.0f, -1.8f, 0f);

        }
        if (isDead == 1)
        {
            transform.Rotate(Vector3.back* rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed / 2 * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
