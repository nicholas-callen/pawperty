using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catAnimator : MonoBehaviour
{
    public masterGameController gameController;
    public Animator animator;

    public void startBonk()
    {
        Debug.Log("Bonk about to start");
        animator.SetTrigger("catSwing");
        transform.position = new Vector3(1.5f, -3.0f, 0f);
        animator.SetTrigger("catIdle");
        Invoke("moveBack", 1.5f);
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.5f);
        
        gameController.LoadScene("punchdown");

    }

    private void moveBack()
    {
        transform.position = new Vector3(-4.0f, -3.0f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameController = FindObjectOfType<masterGameController>();
        transform.position = new Vector3(-4.0f, -3.0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
