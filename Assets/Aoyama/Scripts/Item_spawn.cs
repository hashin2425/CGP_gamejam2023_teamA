using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_spawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint;
    [SerializeField] GameObject Item;

    private float spawnTimer;

    void Start()
    {
        spawnTimer = 0;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            GameObject randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(Item, randomPoint.transform.position, Quaternion.identity);
            spawnTimer = 5;
        }
    }
}
