using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTarget : MonoBehaviour
{
    public GameObject idleBounce;
    public GameObject target;
    public GameObject mover;
    public float ySpawn = 4.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;

    public void spawnPrefab()
    {
        if (target != null)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPos = new Vector3(randomX, 4.0f, 0f);
            GameObject toSpawn = Instantiate(target, spawnPos, Quaternion.identity);
            SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = 2;
            }
            GameObject idleBounce = GameObject.Find("idleBounce");
            toSpawn.transform.parent = idleBounce.transform;
            checkIfHit prefabLogic = toSpawn.GetComponent<checkIfHit>();
            prefabLogic.SetReference(toSpawn);
           
        }

        else
        {
            Debug.Log("Prefab not selected");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnPrefab();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
