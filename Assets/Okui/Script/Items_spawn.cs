using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_spawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoint;
    [SerializeField] GameObject[] item;


    private float spawnTimer;
    private int number;
    private int count;

    void Start()
    {
        spawnTimer = 0;
        count = 0;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            GameObject randomItem = item[Random.Range(0, item.Length)];
            Instantiate(randomItem, spawnPoint[count].transform.position, Quaternion.identity);
            spawnTimer = 5;
            count ++;

        }
    }
}